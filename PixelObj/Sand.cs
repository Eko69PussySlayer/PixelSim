
using System.Transactions;
using OpenTK.Mathematics;
using Raylib_cs;


namespace PixelObj
{
    public class Sand : Base
    {


        public new int x;
        public new int y;

        public float gravity = -9.8f;

        public Sand(int x, int y) : base()
        {
            this.x = x;
            this.y = y;


        }



        public void Gravity()
        {



        }
        public override void Spawn(Vector2i position, Array[,] matrix)
        {
            // Snap the sand to the grid
            Vector2i snappedPosition = new Vector2i(position.X / 4, position.Y / 4);

            // Draw the sand at the snapped position
            Raylib_cs.Rectangle sandRec = new Raylib_cs.Rectangle(snappedPosition.X * 4, snappedPosition.Y * 4, 4, 4);
            Raylib.DrawRectangleRec(sandRec, Color.Beige);

            // Update the matrix at the snapped position
           // Assuming you want to store the Sand object in the matrix









        }


    }





}



