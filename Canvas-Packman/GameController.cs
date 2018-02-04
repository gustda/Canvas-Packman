using Lernmoment.CsharpCanvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
    class GameController
    {
        private CsharpCanvas canvas;

        Packman packman = new Packman();
        bool IsRunningGame = false;

        Pills pills;

        private int _Level = -1;
        private int Level { get { return _Level; } set { _Level = value; canvas.Level = value; } }
        private int _Score = 0;
        private int Score { get { return _Score; } set { _Score = value; canvas.Score = value; } }
        private List<Maze> Levels = new List<Maze>();
        private List<Ghost> Ghosts = new List<Ghost>();


        public GameController(CsharpCanvas aCanvas)
        {
            canvas = aCanvas;
            canvas.SetBackgroundColor(System.Drawing.Color.AliceBlue);
            canvas.Draw += Canvas_Draw;

            StartGame();

            // for continous drawing
            canvas.InitGame(30);
        }

        private void Canvas_Draw()
        {
            CheckKeys();
            if (IsRunningGame)
            {
                DrawMaze();
                DrawPills();

                DrawPackman();
                DrawGhosts();

                if (pills.CheckAndRemovePill(packman.X, packman.Y))
                    Score++;

                if (!CheckPillsLeft())
                    NewLevel();

                if (Levels[Level].CheckCollision(packman)|| CheckGhostCollison(packman))
                {
                    StopGame();
                    canvas.AddGameResult("Game Over  Restart: press N");
                    //canvas.SetBackgroundColor(System.Drawing.Color.Red);
                }
            }
        }

        private bool CheckGhostCollison(Packman packman)
        {
            foreach(var ghost in Ghosts)
            {
                if (ghost.X + ghost.Size / 2 > packman.LeftCornerX && ghost.X - ghost.Size / 2 < packman.LeftCornerX + packman.Size)
                {
                    if (ghost.Y + ghost.Size / 2 > packman.LeftCornerY && ghost.Y - ghost.Size / 2 < packman.LeftCornerY + packman.Size)
                        return true;
                }
            }
            return false;
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

        private void DrawGhosts()
        {
            foreach(var ghost in Ghosts)
            {
                ghost.ProcessGhostStep(Levels[Level].CheckCollision(ghost));
                canvas.AddPicture("Ressources/ghost.gif", ghost.LeftCornerX, ghost.LeftCornerY, ghost.Size, ghost.Size, 0);
            }
        }
            

        private void DrawPills()
        {
            foreach (var pill in pills.GetPills())
            {
                canvas.SetForegroundColor(System.Drawing.Color.Blue);
                canvas.AddCircle(pill.X, pill.Y, pill.Size, Fill.Fill);
            }
        }

        private bool CheckPillsLeft()
        {
            return pills.GetPills().Count > 0;
        }

        private void CheckKeys()
        {
            if (canvas.LastPressedKey != System.Windows.Forms.Keys.None)
            {
                packman.ProcessKey(canvas.LastPressedKey);

                if (canvas.LastPressedKey == System.Windows.Forms.Keys.N)
                {
                    packman = new Packman();
                    StartGame();
                }

                canvas.KeyHandled();
            }
        }

        private void QuitGame()
        {
            StopGame();
            canvas.AddGameResult("You Won  Restart: press N");
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
            Ghosts.Clear();
            if (Levels.Count > Level)
            {
                pills = new Pills();
                for(int i=0;i<=Level;i++)
                {
                    // erzeuge einen neunen Geist je Level
                    Ghosts.Add(new Ghost(25, 25));
                }
            }
            else
            {
                QuitGame();
            }
        }

        private void InitLevel()
        {
            Levels.Clear();            
            // add Level 1
            Levels.Add(new Maze());
            Levels.Add(new Maze());
        }
    }
}
