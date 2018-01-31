using Lernmoment.CsharpCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas_Packman
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CsharpCanvas canvas = new CsharpCanvas();
            GameController launcher = new GameController(canvas);
            canvas.Setup();
        }
    }
}
