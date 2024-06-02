using Microsoft.VisualBasic;
using Raylib_cs;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;
using System.Collections.Generic;
using System;

namespace PixelSim
{
    public class Sand
    {
        public CellType[,] NextSand(CellType[,] grid, int cols, int rows, CellType[,] nextGrid)
        {
            if (grid == null || nextGrid == null)
            {
                throw new ArgumentException("Grid and nextGrid cannot be null");
            }

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (grid[i, j] == CellType.Sand)
                    {
                        if (j < rows - 1 && grid[i, j + 1] == CellType.Empty)
                        {
                            // Move down if possible
                            nextGrid[i, j + 1] = CellType.Sand;
                        }
                        else if (i < cols - 1 && j < rows - 1 && grid[i + 1, j + 1] == CellType.Empty)
                        {
                            // Move down-right if possible
                            nextGrid[i + 1, j + 1] = CellType.Sand;
                        }
                        else if (i > 0 && j < rows - 1 && grid[i - 1, j + 1] == CellType.Empty)
                        {
                            // Move down-left if possible
                            nextGrid[i - 1, j + 1] = CellType.Sand;
                        }
                        else
                        {
                            // Stay in place if no movement is possible
                            nextGrid[i, j] = CellType.Sand;
                        }
                    }
                }
            }
            return nextGrid;
        }
    }
}
