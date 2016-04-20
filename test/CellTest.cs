using Xunit;
using GameOfLife;

namespace GameOfLifeTest
{
    public class CellTest
    {
        
        [Fact]
        public void AliveCellShouldStayAliveWithTwoLivingNeighbours(){
            // given
            Cell cell = new Cell(true);
            
            // when
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            
            // then
            Assert.True(cell.WillBeAlive());
        }
        
        [Fact]
        public void DeadCellShouldStayDeadWithTwoLivingNeighbours(){
            // given
            Cell cell = new Cell(false);
            
            // when
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            
            // then
            Assert.False(cell.WillBeAlive());
        }
        
        [Fact]
        public void DeadCellShouldBecomeAliveWithThreeLivingNeighbours(){
            // given
            Cell cell = new Cell(false);
            
            // when
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            
            // then
            Assert.True(cell.WillBeAlive());
        }
        
        [Fact]
        public void AliveCellShouldStayAliveWithThreeLivingNeighbours(){
            // given
            Cell cell = new Cell(true);
            
            // when
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(false));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            cell.AddNeighbour(new Cell(true));
            
            // then
            Assert.True(cell.WillBeAlive());
        }
    }
    
}
