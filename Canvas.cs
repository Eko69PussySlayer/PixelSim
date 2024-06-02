using Microsoft.VisualBasic;
using Raylib_cs;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;

namespace PixelSim
{
    public class Canvas
    {
        public Camera2D camera;

        int ScreenWidth = 1000;
        int ScreenHeight = 800;

        int w = 5;

        Sand sand = new Sand();
        Water water = new Water();


        CellType currentCellType = CellType.Sand;


        private void DrawWithMouse(CellType[,] grid)
        {

            //Select a cell with 1-9 keys
            if (Raylib.IsKeyDown(KeyboardKey.F1))
            {
                currentCellType = CellType.Sand;

            }
            if (Raylib.IsKeyDown(KeyboardKey.F2))
            {
                currentCellType = CellType.Water;
            }


            if (Raylib.IsMouseButtonDown(0))
            {

                Vector2 mousePos = Raylib.GetMousePosition();
                int x = (int)(mousePos.X / w);
                int y = (int)(mousePos.Y / w);

                grid[x, y] = currentCellType;

            }
        }

        public void InitializeDrawing()
        {
            int cols = ScreenWidth / w;
            int rows = ScreenHeight / w;
            CellType[,] grid = InitializeGrid(cols, rows);

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "PixelSim");
            Raylib.SetTargetFPS(120);

            Draw(grid);
        }

        public CellType[,] InitializeGrid(int cols, int rows)
        {
            if (cols <= 0 || rows <= 0)
            {
                throw new ArgumentException("Cols and rows must be greater than zero.");
            }

            CellType[,] arr = new CellType[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    arr[i, j] = CellType.Empty;
                }
            }

            return arr;
        }

        void NextGeneration(CellType[,] grid)
        {
            int cols = ScreenWidth / w;
            int rows = ScreenHeight / w;

            CellType[,] nextGrid = new CellType[cols, rows];
            nextGrid = sand.NextSand(grid, cols, rows, nextGrid);
            nextGrid = water.NextWater(grid, cols, rows, nextGrid);

            // Update the original grid with the next generation
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    grid[i, j] = nextGrid[i, j];
                }
            }
        }

        public void Draw(CellType[,] grid)
        {
            // Set initial active cells for demonstration purposes
            grid[20, 20] = CellType.Sand;
            grid[21, 20] = CellType.Water;

            // Game Loop
            while (!Raylib.WindowShouldClose())
            {
                // Update to the next generation
                NextGeneration(grid);

                DrawWithMouse(grid);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        if (grid[i, j] == CellType.Sand)
                        {
                            Raylib.DrawRectangle(i * w, j * w, w, w, Color.Beige);
                        }
                        else if (grid[i, j] == CellType.Water)
                        {
                            Raylib.DrawRectangle(i * w, j * w, w, w, Color.Blue);
                        }
                        // Add more conditions for other cell types if needed
                    }
                }

                Raylib.DrawText("FPS: " + Raylib.GetFPS(), 10, 30, 20, Color.Red);
                Raylib.EndDrawing();
            }
        }
    }
}
