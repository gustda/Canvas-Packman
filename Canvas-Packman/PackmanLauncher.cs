using csharp_canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
   

    class PackmanLauncher
    {
        CsharpCanvas canvas;

        Packman packman = new Packman();

        public PackmanLauncher()
        {
            canvas = new CsharpCanvas();

            canvas.Draw += Canvas_Draw;

            // für kontinuierliches Zeichnen
            canvas.Setup(30);            
        }

        private void Canvas_Draw()
        {
            CheckKeys();
            DrawPackman();
        }

        private void DrawPackman()
        {
            canvas.SetForegroundColor(System.Drawing.Color.Yellow);
            canvas.AddCircle(packman.X, packman.Y, packman.Size, Fill.Fill  );
        }

        private void CheckKeys()
        {
            if(canvas.LastPressedKey!= System.Windows.Forms.Keys.None)
            {
                packman.ProcessKey(canvas.LastPressedKey);
                canvas.KeyHandled();
            }
        }
    }
}
