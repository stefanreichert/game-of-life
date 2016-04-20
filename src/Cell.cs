using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife
{
    public class Cell : IPrintable
    {
        private ICollection<Cell> neighbours;
        private bool isAlive;

        public static Cell CreateFromCharacter(char character)
        {
            return new Cell('*'.Equals(character));
        }

        public Cell(bool isAlive)
        {
            this.isAlive = isAlive;
            neighbours = new HashSet<Cell>();
        }

        private int GetNumberOfAliveNeighbours()
        {
            return neighbours.Sum(neighbour => neighbour.isAlive ? 1 : 0);
        }

        internal void AddNeighbour(Cell cell)
        {
            neighbours.Add(cell);
        }

        public bool WillBeAlive()
        {
            var aliveNeighbourCount = GetNumberOfAliveNeighbours();
            return (isAlive && aliveNeighbourCount == 2) || aliveNeighbourCount == 3;
        }

        public void Print(TextWriter writer)
        {
            if (isAlive)
            {
                writer.Write('*');
            }
            else
            {
                writer.Write('.');
            }
        }
    }
}