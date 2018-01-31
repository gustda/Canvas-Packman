using Lernmoment.CsharpCanvas;
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

            // for continous drawing
            canvas.Setup();            
        }

        private void Canvas_Draw()
        {
            CheckKeys();
            DrawMaze();
            DrawPackman();
            if( maze.CheckKollision(packman))
            {
                canvas.SetBackgroundColor(System.Drawing.Color.Red);
            }
            else { canvas.SetBackgroundColor(System.Drawing.Color.AliceBlue); }
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
            packman.ProcessPackmanStep();
            canvas.AddPicture("Ressources/Originalpac.png", packman.LeftCornerX, packman.LeftCornerY, packman.Size, packman.Size, packman.Angle);
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
