using Microsoft.VisualBasic;
using Raylib_cs;
using System.Numerics;
using Vector2 = System.Numerics.Vector2;

namespace PixelSim
{
    public class Canvas
    {
        public Camera2D camera;
        private const int ACTIVE_CELL = 1;
        private const int INACTIVE_CELL = 0;

        int ScreenWidth = 1000;
        int ScreenHeight = 800;

        int w = 5;
        public void InitializeDrawing()
        {

            int cols = ScreenWidth / w;
            int rows = ScreenHeight / w;
            int[,] grid = InitialzieGrid(cols, rows);


            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    grid = InitialzieGrid(cols, rows);
                }
            }



            Raylib.InitWindow(ScreenWidth, ScreenHeight, "PixelSim");

            Raylib.SetTargetFPS(120);


            Draw(grid);
        }

        public int[,] InitialzieGrid(int cols, int rows)
        {
            if (cols <= 0 || rows <= 0)
            {
                throw new ArgumentException("Cols and rows must be greater than zero.");
            }

            int[,] arr = new int[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    arr[i, j] = INACTIVE_CELL;
                }
            }

            return arr;
        }




        void NextGeneration(int[,] grid)
{
    int cols = ScreenWidth / w;
    int rows = ScreenHeight / w;

    int[,] nextGrid = new int[cols, rows];

    // Initialize nextGrid to all inactive cells
    for (int i = 0; i < cols; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            nextGrid[i, j] = INACTIVE_CELL;
        }
    }   

    for (int i = 0; i < cols; i++)
    {
        for (int j = rows - 1; j >= 0; j--) // Start from the bottom row
        {
            if (grid[i, j] == ACTIVE_CELL)
            {
                if (j < rows - 1 && grid[i, j + 1] == INACTIVE_CELL)
                {
                    // Move down if possible
                    nextGrid[i, j + 1] = ACTIVE_CELL;
                }
                else if (i < cols - 1 && j < rows - 1 && grid[i + 1, j + 1] == INACTIVE_CELL)
                {
                    // Move down-right if possible
                    nextGrid[i + 1, j + 1] = ACTIVE_CELL;
                }
                else if (i > 0 && j < rows - 1 && grid[i - 1, j + 1] == INACTIVE_CELL)
                {
                    // Move down-left if possible
                    nextGrid[i - 1, j + 1] = ACTIVE_CELL;
                }
                else
                {
                    // Stay in place if no movement is possible
                    nextGrid[i, j] = ACTIVE_CELL;
                }
            }
        }
    }

    // Update the original grid with the next generation
    for (int i = 0; i < cols; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            grid[i, j] = nextGrid[i, j];
        }
    }
}


        public void Draw(int[,] grid)
        {    //Game Loop
            grid[20, 20] = ACTIVE_CELL;
            while (!Raylib.WindowShouldClose())
            {
                NextGeneration(grid);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Blank);


                if (Raylib.IsMouseButtonDown(0))
                {
                    // Get the mouse position
                    Vector2 mousePos = Raylib.GetMousePosition();
                    int x = (int)mousePos.X / w;
                    int y = (int)mousePos.Y / w;
                    if (grid[x, y] == INACTIVE_CELL)
                    {
                        grid[x, y] = ACTIVE_CELL;
                    }
                    else
                    {
                        grid[x, y] = INACTIVE_CELL;
                    }

                }

                for (int i = 0; i < grid.GetLength(0); i++)
                {

                    for (int j = 0; j < grid.GetLength(1); j++)
                    {

                        if (grid[i, j] == ACTIVE_CELL)
                        {
                            Raylib.DrawRectangle(i * w, j * w, w, w, Color.Beige);
                        }



                    }

                }




                Raylib.DrawText("FPS: " + Raylib.GetFPS(), 10, 30, 20, Color.Red);
                Raylib.EndDrawing();
            }



        }
    }
}