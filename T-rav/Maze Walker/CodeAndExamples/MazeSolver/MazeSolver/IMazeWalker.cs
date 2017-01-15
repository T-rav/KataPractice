using System;

namespace MazeSolver
{
    public interface IMazeWalker
    {
        void WalkMaze(Action<string> output, IMazeGrid maze);
    }
}