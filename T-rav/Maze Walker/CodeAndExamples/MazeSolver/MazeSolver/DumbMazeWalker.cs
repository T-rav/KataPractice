using System;

namespace MazeSolver
{
    public class DumbMazeWalker : IMazeWalker
    {
        private readonly IMazeGrid _mMazeGrid;
        private Orientation _mDirec;

        private Point CurrentPosition { get; set; }

        public DumbMazeWalker(IMazeGrid mazeGrid)
        {
            _mMazeGrid = mazeGrid;
            CurrentPosition = _mMazeGrid.StartPosition;
            _mDirec = Orientation.South;
        }

        public void WalkMaze(Action<string> output, IMazeGrid maze)
        {
            var endOfMazeReached = false;

            while (!endOfMazeReached)
            {
                var couldMoveForward = MoveForward();

                if (!couldMoveForward)
                {
                    TurnRight();
                }
                else
                {
                    if (CanSeeLeftTurning())
                    {
                        TurnLeft();
                    }
                }

                endOfMazeReached = maze.AtFinish(CurrentPosition);
                output(CurrentPosition.ToString());
            }

            output("Reached end of maze! :)");
        }

        private bool CanSeeLeftTurning()
        {
            var pointToOurLeft = new Point(CurrentPosition.X, CurrentPosition.Y);

            switch (_mDirec)
            {
                case Orientation.North:
                    pointToOurLeft.X -= 1;
                    break;
                case Orientation.South:
                    pointToOurLeft.X += 1;
                    break;
                case Orientation.East:
                    pointToOurLeft.Y -= 1;
                    break;
                case Orientation.West:
                    pointToOurLeft.Y += 1;
                    break;
                default:
                    throw new Exception();
            }

            return _mMazeGrid.IsPointPartOfMaze(pointToOurLeft);
        }

        private void TurnRight()
        {
            switch (_mDirec)
            {
                case Orientation.North:
                    _mDirec = Orientation.East;
                    break;
                case Orientation.East:
                    _mDirec = Orientation.South;
                    break;
                case Orientation.South:
                    _mDirec = Orientation.West;
                    break;
                case Orientation.West:
                    _mDirec = Orientation.North;
                    break;
                default:
                    throw new Exception();
            }
        }

        private void TurnLeft()
        {
            switch (_mDirec)
            {
                case Orientation.North:
                    _mDirec = Orientation.West;
                    break;
                case Orientation.West:
                    _mDirec = Orientation.South;
                    break;
                case Orientation.South:
                    _mDirec = Orientation.East;
                    break;
                case Orientation.East:
                    _mDirec = Orientation.North;
                    break;
                default:
                    throw new Exception();
            }
        }

        private bool MoveForward()
        {
            var desiredPoint = new Point(CurrentPosition.X, CurrentPosition.Y);

            switch (_mDirec)
            {
                case Orientation.North:
                    desiredPoint.Y -= 1;
                    break;
                case Orientation.South:
                    desiredPoint.Y += 1;
                    break;
                case Orientation.East:
                    desiredPoint.X += 1;
                    break;
                case Orientation.West:
                    desiredPoint.X -= 1;
                    break;
                default:
                    throw new Exception();
            }

            var canMoveForward = _mMazeGrid.IsPointPartOfMaze(desiredPoint);
            if (canMoveForward) CurrentPosition = desiredPoint;
            return canMoveForward;
        }
    }
}