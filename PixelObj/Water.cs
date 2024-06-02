namespace PixelSim
{
    public class Water
    {
        public CellType[,] NextWater(CellType[,] grid, int cols, int rows, CellType[,] nextGrid)
        {
            if (grid == null || nextGrid == null)
            {
                throw new ArgumentException("Grid and nextGrid cannot be null");
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (grid[i, j] == CellType.Water)
                    {
                        if (j < rows - 1 && grid[i, j + 1] == CellType.Empty)
                        {
                            // Move down if possible
                            nextGrid[i, j + 1] = CellType.Water;
                        }
                        else if (i > 0 && j < rows - 1 && grid[i - 1, j + 1] == CellType.Empty)
                        {
                            // Move down-left if possible
                            nextGrid[i - 1, j + 1] = CellType.Water;
                        }
                        else if (i < cols  && j < rows  && grid[i , j] == CellType.Empty)
                        {
                            // Move down-right if possible
                            nextGrid[i + 1, j + 1] = CellType.Water;
                        }
                        else if (i > 0 && grid[i, j] == CellType.Empty)
                        {
                            // Move left if possible
                            nextGrid[i -1, j] = CellType.Water;
                        }
                        else if (i < cols - 1 && grid[i + 1, j] == CellType.Empty)
                        {
                            // Move right if possible
                            nextGrid[i + 1, j] = CellType.Water;
                        }
                        else
                        {
                            // Stay in place if no movement is possible
                            nextGrid[i, j] = CellType.Water;
                        }
                    }
                }
            }
            return nextGrid;
        }
    }
}
