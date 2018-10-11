using PlutoRoverNavigator.Models;
using PlutoRoverNavigator.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace PlutoRoverNavigator.Controllers
{
    public class NavigationController : ApiController
    {
        private List<char> _validCommands = new List<char>() { 'F', 'B', 'L', 'R' };
        public RoverPosition GetPosition()
        {
            return new RoverPosition();
        }

        /// <summary>
        /// Checks if command is valid or not
        /// </summary>
        public string ExecuteCommand(char command)
        {
            if (_validCommands.Contains(command))
                return "command_valid_and_executed";
            else
                return "invalid_command";
        }

        /// <summary>
        /// Checks and execute command
        /// </summary>
        public RoverPosition ExecuteCommand(string command, RoverPosition position, List<Tuple<int, int>> Obstacles = null)
        {
            Obstacles = Obstacles ?? new List<Tuple<int, int>>();

            foreach (var singleCommand in command)
            {
                if (_validCommands.Contains(singleCommand))
                {
                    switch (singleCommand)
                    {
                        case 'F':
                            position = CommandHelper.MoveForward(position, Obstacles);
                            break;
                        case 'B':
                            position = CommandHelper.MoveBackward(position, Obstacles);
                            break;
                        case 'L':
                            position = CommandHelper.TurnLeft(position);
                            break;
                        case 'R':
                            position = CommandHelper.TurnRight(position);
                            break;
                        default:
                            break;
                    }

                    //stop executing command if obstacle detected
                    if (position.ObstaclePresent)
                        break;
                }
            }
            return position;
        }

        public RoverPosition CheckObstacle(bool moveRover, char command, RoverPosition pos, List<Tuple<int, int>> Obstacles)
        {
            if (command == 'F' || command == 'B')
            {
                int newXCoordinate = -1, newYCoordinate = -1;

                switch (command)
                {
                    case 'F':
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
                        break;
                    case 'B':
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
                        break;
                    default:
                        break;
                }

                //check if obstacle present on new coordinates (after wrapping)
                RoverPosition tempPosition = new RoverPosition() {
                    xCoordinate = newXCoordinate,
                    yCoordinate = newYCoordinate,
                    Facing = pos.Facing,
                    ObstaclePresent = false
                };
                tempPosition = Wrapper.ApplyWrapperToPosition(tempPosition);

                Tuple<int, int> newPosition = new Tuple<int, int>(tempPosition.xCoordinate, tempPosition.yCoordinate);
                pos.ObstaclePresent = Obstacles.Contains(newPosition);

                if (moveRover && !pos.ObstaclePresent)
                {
                    pos.xCoordinate = tempPosition.xCoordinate;
                    pos.yCoordinate = tempPosition.yCoordinate;
                }

            }

            return pos;

        }
    }
}
