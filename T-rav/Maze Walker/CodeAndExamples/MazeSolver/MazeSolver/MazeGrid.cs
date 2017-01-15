namespace MazeSolver
{
    public class MazeGrid : IMazeGrid
    {
        // +--------> +ve X
        // |
        // |
        // |
        // |
        // v
        // +ve Y

        public Point StartPosition { get; }

        private Point Finish { get; }

        private bool[][] Grid { get; }

        public MazeGrid(bool[][] grid, Point start, Point finish)
        {
            Grid = grid;
            StartPosition = start;
            Finish = finish;
        }

        public bool AtFinish(Point currentPosition)
        {
            return Finish.X == currentPosition.X && Finish.Y == currentPosition.Y;
        }

        public bool IsPointPartOfMaze(Point target)
        {
            return Grid[target.Y][target.X];
        }
    }
}