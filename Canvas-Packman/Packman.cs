using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_Packman
{
    class Packman
    {
      public   int X { get; private set; }
       public  int Y { get; private set; }
        public int Size { get; private  set; }

        public int Step { get; private set; }
        

        public Packman()
        {
            Size = 20;
            Step = 10;
            X = 200;
            Y=250;
        }

        public void ProcessKey (Keys key)
        {
            // handle Packman Steps
            switch(key)
            {
                case Keys.Down:
                    if (Y < 600 - Step-Size)
                        Y = Y + Step;
                    break;
                case Keys.Up:
                    if (Y > 0 + Step+Size)
                        Y = Y - Step;
                    break;                    
                case Keys.Left:
                    if (X > 0 + Step+ Size)
                        X = X - Step;
                    break;
                case Keys.Right:
                    if (X < 600 - Step- Size)
                        X = X + Step;
                    break;
            }
        }
    }
}
