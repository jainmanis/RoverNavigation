using PlutoRoverNavigator.Models;
using PlutoRoverNavigator.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public RoverPosition ExecuteCommand(char command, RoverPosition position)
        {
            if (_validCommands.Contains(command))
            {
                switch (command)
                {
                    case 'F':
                        position = CommandHelper.MoveForward(position);
                        break;
                    case 'B':
                        position = CommandHelper.MoveBackward(position);
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

                if (position.yCoordinate == 100)
                    position.yCoordinate = 0;

                if (position.yCoordinate == -1)
                    position.yCoordinate = 99;

                if (position.xCoordinate == -1)
                    position.xCoordinate = 99;

                if (position.xCoordinate == 100)
                    position.xCoordinate = 0;

            }

            return position;
        }
    }
}
