using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
  public   class Pill
    {
        public int Size { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Pill() { Size = 10; }

        public Pill(int x, int y)
        {
            X = x;
            Y = y;
            Size = 10;
        }
    }
}
