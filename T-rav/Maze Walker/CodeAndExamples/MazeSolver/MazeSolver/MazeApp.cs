using System;

namespace MazeSolver
{
    public class MazeApp
    {
        public static void Main()
        {
            var mazeApp = new MazeApp();
            /*
             * maze1.txt works
             * maze2.txt gets stuck
             * If using NUnit 3 - You will need to append TestContext.CurrentContext.TestDirectory to front of path to make it work properly
             * And do not use Path.Combine. If Path1 contains a C:\ it will always just return path2? Ask MS why.
             */
            var output = new Action<string>(Console.WriteLine);
            mazeApp.Run(@"MazeFiles\maze1.txt", output);
        }

        public void Run(string mazeFilePath, Action<string> output)
        {
            var maze = new MazeLoader(mazeFilePath).LoadMaze();
            var entity = new DumbMazeWalker(maze);

            entity.WalkMaze(output, maze);
        }
    }
}