using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas_Packman
{
    class Maze
    {
        public List<MazeWall> Walls { get; private set; }

        public Maze()
        {
            Walls = new List<MazeWall>();

            // add frame        
            Walls.Add(new MazeWall(-2, -2, 600, Direction.Horizontal));
            Walls.Add(new MazeWall(-2, -2, 600, Direction.Vertical));
            Walls.Add(new MazeWall(0, 597, 600, Direction.Horizontal));
            Walls.Add(new MazeWall(597, 0, 600, Direction.Vertical));

            Walls.Add(new MazeWall(100, 100, 100, Direction.Horizontal));
            Walls.Add(new MazeWall(100, 100, 100, Direction.Vertical));
            Walls.Add(new MazeWall(195,100, 100, Direction.Vertical));

            Walls.Add(new MazeWall(300, 100, 200, Direction.Horizontal));
            Walls.Add(new MazeWall(300, 100, 300, Direction.Vertical));

            Walls.Add(new MazeWall(300, 400, 50, Direction.Horizontal));
            Walls.Add(new MazeWall(350, 400, 100, Direction.Vertical));
            Walls.Add(new MazeWall(420, 400, 80, Direction.Horizontal));
            Walls.Add(new MazeWall(500, 100, 305, Direction.Vertical));
        }

        public bool CheckKollision(Packman packman)
        {
            foreach(var wall in Walls)
            {
                if(packman.X+packman.Size/2>wall.X && packman.X-packman.Size/2<wall.X+wall.Width)
                {
                    // packman is in the horizantal district
                    if (packman.Y + packman.Size/2 > wall.Y && packman.Y - packman.Size/2 < wall.Y + wall.Height)
                        return true;
                }
            }
            return false;
        }
    }
}
