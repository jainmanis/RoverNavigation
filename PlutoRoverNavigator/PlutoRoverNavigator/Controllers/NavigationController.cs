using PlutoRoverNavigator.Models;
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

        public string ExecuteCommand(char command)
        {
            if (_validCommands.Contains(command))
                return "command_valid_and_executed";
            else
                return "invalid_command";
        }

        public RoverPosition ExecuteCommand(char command, RoverPosition position)
        {
            if (_validCommands.Contains(command))
            {
                switch (position.Facing)
                {
                    case 'N':
                        if (command == 'F')
                            position.yCoordinate = position.yCoordinate + 1;
                        else if (command == 'B')
                            position.yCoordinate = position.yCoordinate - 1;
                        else if (command == 'L')
                            position.Facing = 'W';
                        else if (command == 'R')
                            position.Facing = 'E';

                        break;
                    case 'S':
                        if (command == 'F')
                            position.yCoordinate = position.yCoordinate - 1;
                        else if (command == 'B')
                            position.yCoordinate = position.yCoordinate + 1;
                        else if (command == 'L')
                            position.Facing = 'E';
                        else if (command == 'R')
                            position.Facing = 'W';
                        break;
                    case 'W':
                        if (command == 'F')
                            position.xCoordinate = position.xCoordinate - 1;
                        else if (command == 'B')
                            position.xCoordinate = position.xCoordinate + 1;
                        else if (command == 'L')
                            position.Facing = 'S';
                        else if (command == 'R')
                            position.Facing = 'N';
                        break;
                    case 'E':
                        if (command == 'F')
                            position.xCoordinate = position.xCoordinate + 1;
                        else if (command == 'B')
                            position.xCoordinate = position.xCoordinate - 1;
                        else if (command == 'L')
                            position.Facing = 'N';
                        else if (command == 'R')
                            position.Facing = 'S';
                        break;
                    default:
                        break;
                }
            }
            return position;
        }

    }
}
