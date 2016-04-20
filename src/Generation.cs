using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GameOfLife
{
    public class Generation : IPrintable
    {
        private IList<Cell> cells;
        private Cell[][] grid;

        public Generation(int columnCount, int rowCount, IList<Cell> cellsInGrid)
        {
            cells = cellsInGrid;
            grid = CreateGrid(columnCount, rowCount, cells);
            InitializeNeighboursForGrid(cells, grid);
        }

        private void InitializeNeighboursForGrid(IList<Cell> cells, Cell[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = cells.Count / rowCount;
            for (int cellIndex = 0; cellIndex < cells.Count; cellIndex++)
            {
                Cell cell = cells[cellIndex];
                IEnumerable<int[]> neighbourCoordinates = EvaluateValidNeighbourCoordinates(cellIndex, columnCount, rowCount);
                InitializeNeighboursForCell(cell, grid, neighbourCoordinates);
            }
        }

        private IEnumerable<int[]> EvaluateValidNeighbourCoordinates(int cellIndex, int columnCount, int rowCount)
        {
            int rowIndex = cellIndex / columnCount;
            int columIndex = cellIndex % columnCount;
            // create possible coordinates of neighbours
            var neighbourCoordinates = new List<int[]>();
            neighbourCoordinates.Add(new int[] { rowIndex - 1, columIndex - 1 });
            neighbourCoordinates.Add(new int[] { rowIndex - 1, columIndex });
            neighbourCoordinates.Add(new int[] { rowIndex - 1, columIndex + 1 });
            neighbourCoordinates.Add(new int[] { rowIndex, columIndex - 1 });
            neighbourCoordinates.Add(new int[] { rowIndex, columIndex + 1 });
            neighbourCoordinates.Add(new int[] { rowIndex + 1, columIndex - 1 });
            neighbourCoordinates.Add(new int[] { rowIndex + 1, columIndex });
            neighbourCoordinates.Add(new int[] { rowIndex + 1, columIndex + 1 });
            // filter the valid ones
            return neighbourCoordinates.Where(coordinate => IsValidGridCoordinate(coordinate, columnCount, rowCount));
        }
        private void InitializeNeighboursForCell(Cell cell, Cell[][] grid, IEnumerable<int[]> neighbourCoordinates)
        {
            foreach (int[] coordinate in neighbourCoordinates)
            {
                int neighbourRowIndex = coordinate[0];
                int neighbourColumnIndex = coordinate[1];
                cell.AddNeighbour(grid[neighbourRowIndex][neighbourColumnIndex]);
            }
        }

        private bool IsValidGridCoordinate(int[] coordinate, int columnCount, int rowCount)
        {
            bool validRowIndex = coordinate[0] >= 0 && coordinate[0] < rowCount;
            bool validColumnIndex = coordinate[1] >= 0 && coordinate[1] < columnCount;
            return validRowIndex && validColumnIndex;
        }

        private Cell[][] CreateGrid(int columnCount, int rowCount, IList<Cell> cells)
        {
            var newGrid = new Cell[rowCount][];
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                newGrid[rowIndex] = new Cell[columnCount];
                for (int columIndex = 0; columIndex < columnCount; columIndex++)
                {
                    int cellIndex = (rowIndex * columnCount) + columIndex;
                    newGrid[rowIndex][columIndex] = cells[cellIndex];
                }
            }
            return newGrid;
        }

        public void Print(TextWriter writer)
        {
            int rowCount = grid.Length;
            int columnCount = cells.Count / rowCount;
            for (int index = 0; index < cells.Count; index++)
            {
                int rowIndex = index / columnCount;
                int columIndex = index % columnCount;
                if (columIndex == 0 && rowIndex != 0)
                {
                    writer.WriteLine();
                }
                grid[rowIndex][columIndex].Print(writer);
            }
        }

        public Generation Next()
        {
            int rowCount = grid.Length;
            int columnCount = cells.Count / rowCount;

            IList<Cell> nextGenerationCells = cells.Select(cell => new Cell(cell.WillBeAlive())).ToList();

            return new Generation(rowCount, columnCount, nextGenerationCells);
        }
    }
}