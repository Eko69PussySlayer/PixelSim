//Base Class for all Pixel Objects
using OpenTK.Mathematics;

namespace PixelObj
{
    public abstract class Base
    {




        //make a Base class that will be used for all pixel objects Paremeters are; X,Y,ID
        public int x { get; set; }	
        public int y { get; set; }
        public enum id {}

        public abstract void Spawn(Vector2i position, Array[,] Matrix);
       
      



    }
    }
