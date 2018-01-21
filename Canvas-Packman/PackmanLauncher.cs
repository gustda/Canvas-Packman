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
        Maze maze = new Maze();

        public PackmanLauncher()
        {
            canvas = new CsharpCanvas();
            canvas.SetBackgroundColor(System.Drawing.Color.AliceBlue);
            canvas.Draw += Canvas_Draw;

            // für kontinuierliches Zeichnen
            canvas.Setup(30);            
        }

        private void Canvas_Draw()
        {
            CheckKeys();
            DrawMaze();
            DrawPackman();
        }

        private void DrawMaze()
        {
            canvas.SetForegroundColor(System.Drawing.Color.Brown);
            for(int i=0;i<maze.Walls.Count;i++)
            {
                canvas.AddRectangle(maze.Walls[i].X, maze.Walls[i].Y, maze.Walls[i].Width, maze.Walls[i].Height, Fill.Fill);
            }
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
