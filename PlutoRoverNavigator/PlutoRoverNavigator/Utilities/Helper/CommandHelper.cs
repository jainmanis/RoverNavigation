using PlutoRoverNavigator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRoverNavigator.Utilities.Helper
{
    public class CommandHelper
    {
        public static RoverPosition MoveForward(RoverPosition pos)
        {
            switch (pos.Facing)
            {
                case 'N':
                    pos.yCoordinate++;
                    break;
                case 'S':
                    pos.yCoordinate--;
                    break;
                case 'W':
                    pos.xCoordinate--;
                    break;
                case 'E':
                    pos.xCoordinate++;
                    break;
                default:
                    break;
            }
            return pos;
        }

        public static RoverPosition MoveBackward(RoverPosition pos)
        {
            switch (pos.Facing)
            {
                case 'N':
                    pos.yCoordinate--;
                    break;
                case 'S':
                    pos.yCoordinate++;
                    break;
                case 'W':
                    pos.xCoordinate++;
                    break;
                case 'E':
                    pos.xCoordinate--;
                    break;
                default:
                    break;
            }
            return pos;
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