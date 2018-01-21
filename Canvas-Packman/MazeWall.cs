using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
    public enum Direction
    {
        Vertical,
        Horizontal,
    }

    class MazeWall
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        private static int _Thickness = 5;
        public static int Thickness
        {
            get { return _Thickness; }
        }

        public MazeWall(int x, int y, int length, Direction direction)
        {
            X = x;
            Y = y;
            switch (direction)
            {
                case Direction.Horizontal:
                    Width =  length;
                    Height = Thickness;
                    break;
                case Direction.Vertical:
                    Width =  Thickness;
                    Height = length;
                    break;
            }
        }
    }
}
