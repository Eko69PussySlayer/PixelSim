using Raylib_cs;
using PixelObj;
using System.Numerics;
using OpenTK.Mathematics;
using Vector2 = System.Numerics.Vector2;





namespace PixelSim
{
    public class Canvas
    {
        public Camera2D camera;

        public void InitializeDrawing()
        {
            int ScreenWidth = 1000;
            int ScreenHeight = 800;




            Raylib.InitWindow(ScreenWidth, ScreenHeight, "PixelSim");

            Raylib.SetTargetFPS(120);

            Draw();
        }

        private Array[,] InitMatrix()

        {
            int ScreenWidth = 1000;
            int ScreenHeight = 800;

            //Initialize the Matrix based on the size of the screen the matrix should be an array of 1000x800 cells and each cell is 4x4 pixels
            Array[,] matrix = new Array[ScreenWidth / 4, ScreenHeight / 4];

                return matrix;




        }





        public void Draw()
        {

            Array[,] Matrix;
          Matrix = InitMatrix();

        


            while (!Raylib.WindowShouldClose())
            {
                Vector2 mousePosition = Raylib.GetMousePosition();

                int mouseX = (int)mousePosition.X;
                int mouseY = (int)mousePosition.Y;




                Raylib.BeginDrawing();

                //Spawn Sand at the position of the mouse
                Sand sand = new Sand(mouseX / 4, mouseY / 4);
                sand.Spawn(new Vector2i(mouseX, mouseY), Matrix);

                //Draw Debug text
                Raylib.EndDrawing();
                Raylib.DrawText("Mouse Position: " + mouseX + ", " + mouseY, 10, 10, 20, Color.Red);
                Raylib.DrawText("FPS: " + Raylib.GetFPS(), 10, 30, 20, Color.Red);
                Raylib.ClearBackground(Color.Black);







            }

        }
    }
}