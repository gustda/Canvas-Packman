using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_Packman
{
    class Packman
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int LeftCornerX { get { return (int)(X - Size / 2); } }
        public int LeftCornerY { get { return (int)(Y - Size / 2); } }
        public int Size { get; private set; }
        public int Angle { get; private set; }

        public int Step { get; private set; }

        public int Speed { get; private set; }

        private int steps = 0;
       public void ProcessPackmanStep()
        {
            if (steps == 0)
            {

                switch (Angle)
                {
                    case 90:
                        if (Y <= 600 - Size)
                            Y = Y + Step;
                        break;
                    case 270:
                        if (Y >= 0 + Size)
                            Y = Y - Step;
                        break;
                    case 180:
                        if (X >= 0 + Size)
                            X = X - Step;
                        break;
                    case 0:
                        if (X <= 600 - Size)
                            X = X + Step;
                        break;
                }
                steps++;
            }
            else
            {
                steps++;
                if(steps==Speed)
                { steps = 0; }
            }
        }

        public Packman()
        {
            Size = 50;
            Step = 10;
            X = 200;
            Y=250;
            Speed = 5;
        }

        public void ProcessKey (Keys key)
        {
            // handle Packman Steps
            switch(key)
            {
                case Keys.Down:
                    Angle = 90;
                    break;
                case Keys.Up:
                    Angle = 270;
                    break;                    
                case Keys.Left:
                    Angle = 180;
                    break;
                case Keys.Right:
                    Angle = 0;
                    break;
            }
        }
    }
}
