using PlutoRoverNavigator.Models;
using System;
using System.Collections.Generic;

namespace PlutoRoverNavigator.Utilities.Helper
{
    public class CommandHelper
    {
        /// <summary>
        /// Checks if obstacle present (if not move to the new position)
        /// </summary>
        public static RoverPosition CheckObstacleAndMove(RoverPosition oldPosition, RoverPosition newPosition, List<Tuple<int, int>> Obstacles)
        {
            newPosition = Wrapper.ApplyWrapperToPosition(newPosition);

            Tuple<int, int> newCoordinates = new Tuple<int, int>(newPosition.xCoordinate, newPosition.yCoordinate);

            oldPosition.ObstaclePresent = Obstacles.Contains(newCoordinates);

            if (!oldPosition.ObstaclePresent)
            {
                oldPosition.xCoordinate = newPosition.xCoordinate;
                oldPosition.yCoordinate = newPosition.yCoordinate;
            }

            return oldPosition;
        }

        public static RoverPosition MoveForward(RoverPosition pos, List<Tuple<int, int>> Obstacles)
        {
            int newXCoordinate = -1, newYCoordinate = -1;

            switch (pos.Facing)
            {
                case 'N':
                    newXCoordinate = pos.xCoordinate;
                    newYCoordinate = pos.yCoordinate + 1;
                    break;
                case 'S':
                    newXCoordinate = pos.xCoordinate;
                    newYCoordinate = pos.yCoordinate - 1;
                    break;
                case 'W':
                    newXCoordinate = pos.xCoordinate - 1;
                    newYCoordinate = pos.yCoordinate;
                    break;
                case 'E':
                    newXCoordinate = pos.xCoordinate + 1;
                    newYCoordinate = pos.yCoordinate;
                    break;
                default:
                    break;
            }

            //new position
            RoverPosition newPosition = new RoverPosition()
            {
                xCoordinate = newXCoordinate,
                yCoordinate = newYCoordinate,
                Facing = pos.Facing,
                ObstaclePresent = false
            };

            return CheckObstacleAndMove(pos, newPosition, Obstacles);
        }

        public static RoverPosition MoveBackward(RoverPosition pos, List<Tuple<int, int>> Obstacles)
        {
            int newXCoordinate = -1, newYCoordinate = -1;

            switch (pos.Facing)
            {
                case 'N':
                    newXCoordinate = pos.xCoordinate;
                    newYCoordinate = pos.yCoordinate - 1;
                    break;
                case 'S':
                    newXCoordinate = pos.xCoordinate;
                    newYCoordinate = pos.yCoordinate + 1;
                    break;
                case 'W':
                    newXCoordinate = pos.xCoordinate + 1;
                    newYCoordinate = pos.yCoordinate;
                    break;
                case 'E':
                    newXCoordinate = pos.xCoordinate - 1;
                    newYCoordinate = pos.yCoordinate;
                    break;
                default:
                    break;
            }

            //new position
            RoverPosition newPosition = new RoverPosition()
            {
                xCoordinate = newXCoordinate,
                yCoordinate = newYCoordinate,
                Facing = pos.Facing,
                ObstaclePresent = false
            };

            return CheckObstacleAndMove(pos, newPosition, Obstacles); ;

        }

        public static RoverPosition TurnLeft(RoverPosition pos)
        {
            switch (pos.Facing)
            {
                case 'N':
                    pos.Facing = 'W';
                    break;
                case 'S':
                    pos.Facing = 'E';
                    break;
                case 'W':
                    pos.Facing = 'S';
                    break;
                case 'E':
                    pos.Facing = 'N';
                    break;
                default:
                    break;
            }
            return pos;
        }

        public static RoverPosition TurnRight(RoverPosition pos)
        {
            switch (pos.Facing)
            {
                case 'N':
                    pos.Facing = 'E';
                    break;
                case 'S':
                    pos.Facing = 'W';
                    break;
                case 'W':
                    pos.Facing = 'N';
                    break;
                case 'E':
                    pos.Facing = 'S';
                    break;
                default:
                    break;
            }
            return pos;
        }

    }
}