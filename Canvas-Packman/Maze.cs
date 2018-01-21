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
            Walls.Add(new MazeWall(0, 0, 600, Direction.Horizontal));
            Walls.Add(new MazeWall(0, 0, 600, Direction.Vertical));
            Walls.Add(new MazeWall(600 - MazeWall.Thickness, 0,600, Direction.Vertical));
            Walls.Add(new MazeWall(0, 600-MazeWall.Thickness, 600, Direction.Horizontal));
        
            Walls.Add(new MazeWall(100, 100, 100, Direction.Horizontal));
            Walls.Add(new MazeWall(100, 100, 100, Direction.Vertical));
            Walls.Add(new MazeWall(100, 200, 100, Direction.Horizontal));
            Walls.Add(new MazeWall(195,100, 100, Direction.Vertical));

            Walls.Add(new MazeWall(300, 100, 200, Direction.Horizontal));
            Walls.Add(new MazeWall(300, 100, 300, Direction.Vertical));

            Walls.Add(new MazeWall(300, 400, 50, Direction.Horizontal));
            Walls.Add(new MazeWall(350, 400, 100, Direction.Vertical));
            Walls.Add(new MazeWall(400, 300, 200, Direction.Vertical));
            Walls.Add(new MazeWall(400, 400, 100, Direction.Horizontal));
            Walls.Add(new MazeWall(500, 100, 305, Direction.Vertical));
        }

        
    }
}
