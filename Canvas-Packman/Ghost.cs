using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
    class Ghost
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
        public void ProcessGhostStep(bool collison)
        {
            if (steps == 0)
            {
                if(collison)
                {
                    var newAngle = new Random();
                    var oldAngle = Angle;
                    switch(newAngle.Next(1,4))
                    {
                        case 1:
                            Angle = 90;
                            break;
                        case 2:
                            Angle = 180;
                            break;
                        case 3:
                            Angle = 270;
                            break;
                        case 4:
                            Angle = 0;
                            break;
                    }
                    if (Angle == oldAngle)
                    {
                        // wiederholen des Steps, da kein neuer Winkel berechnet wurde
                        if (Angle != 270)
                            Angle += 90;
                        else
                            Angle = 0;
                    }
                }
                
                switch (Angle)
                {
                    case 90:
                        Y = Y + Step;
                        break;
                    case 270:
                        Y = Y - Step;
                        break;
                    case 180:
                        X = X - Step;
                        break;
                    case 0:
                        X = X + Step;
                        break;
                }

                if (X >= 600 || Y >= 600)
                {
                    if (Y >= 600)
                        Y = 5;
                    if (X >= 600)
                        X = 5;
                }
                else
                {
                    if (Y <= 0)
                        Y = 595;
                    if (X <= 0)
                        X = 595;
                }

                steps++;
            }
            else
            {
                steps++;
                if (steps == Speed)
                { steps = 0; }
            }
        }

        public Ghost(int x, int y)
        {
            Size = 40;
            Step = 10;
            X = x;
            Y = y;
            Speed = 5;
            ProcessGhostStep(true);
        }
    }
}
