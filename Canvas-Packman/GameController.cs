using csharp_canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
    class GameController
    {
        CsharpCanvas canvas;

        Packman packman = new Packman();
        bool IsRunningGame = false;

        Pills pills;

        private int _Level = -1;
        private int Level { get { return _Level; } set { _Level = value; canvas.Level = value; } }
        private int _Score = 0;
        private int Score { get { return _Score; } set { _Score = value; canvas.Score = value; } }
        private List<Maze> Levels = new List<Maze>();


        public GameController()
        {
            canvas = new CsharpCanvas();
            canvas.SetBackgroundColor(System.Drawing.Color.AliceBlue);
            canvas.Draw += Canvas_Draw;

            StartGame();

            // for continous drawing
            canvas.SetupGame(30);            
        }

        private void Canvas_Draw()
        {
            CheckKeys();
            if (IsRunningGame)
            {                
                DrawMaze();
                DrawPills();

                DrawPackman();

                if (pills.CheckAndRemovePill(packman.X, packman.Y))
                    Score++;

                if (Levels[Level].CheckKollision(packman))
                {
                    StopGame();
                    canvas.AddGameResult("Game Over  Restart: press N");
                    //canvas.SetBackgroundColor(System.Drawing.Color.Red);
                }
            }
        }

        private void DrawMaze()
        {
            canvas.SetForegroundColor(System.Drawing.Color.Brown);
            for (int i = 0; i < Levels[Level].Walls.Count; i++)
            {
                canvas.AddRectangle(Levels[Level].Walls[i].X, Levels[Level].Walls[i].Y, Levels[Level].Walls[i].Width, Levels[Level].Walls[i].Height, Fill.Fill);
            }
        }

        private void DrawPackman()
        {
            packman.ProcessPackmanStep();
            canvas.AddPicture("Ressources/Originalpac.png", packman.LeftCornerX, packman.LeftCornerY, packman.Size, packman.Size, packman.Angle);
        }

        private void DrawPills()
        {
            foreach(var pill in pills.GetPills())
            {
                canvas.SetForegroundColor(System.Drawing.Color.Blue);
                canvas.AddCircle(pill.X, pill.Y, pill.Size, Fill.Fill);
            }
        }

        private void CheckKeys()
        {
            if (canvas.LastPressedKey != System.Windows.Forms.Keys.None)
            {
                packman.ProcessKey(canvas.LastPressedKey);

                if(canvas.LastPressedKey== System.Windows.Forms.Keys.N)
                {
                    packman = new Packman();
                    StartGame();
                }

                canvas.KeyHandled();
            }
        }

        private void StopGame()
        {
            IsRunningGame = false;
        }

        public void StartGame()
        {
            Score = 0;
            Level = -1;
            InitLevel();

            NewLevel();

            canvas.AddGameResult("");

            IsRunningGame = true;
        }

        private void NewLevel()
        {
            Level++;
            if (Levels.Count>Level)
            {
                pills = new Pills();
            }
        }

        private void InitLevel()
        {
            Levels.Add(new Maze());
        }
    }
}
