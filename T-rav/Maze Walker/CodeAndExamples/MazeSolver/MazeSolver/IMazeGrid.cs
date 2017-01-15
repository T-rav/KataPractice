namespace MazeSolver
{
    public interface IMazeGrid
    {
        Point StartPosition { get; }

        bool AtFinish(Point currentPosition);
        bool IsPointPartOfMaze(Point target);
    }
}