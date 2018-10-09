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
                if (position.Facing == 'N')
                {
                    if (command == 'F')
                        position.yCoordinate = position.yCoordinate + 1;
                    else if (command == 'B')
                        position.yCoordinate = position.yCoordinate - 1;
                }

                if (position.Facing == 'S')
                {
                    if (command == 'F')
                        position.yCoordinate = position.yCoordinate - 1;
                    else if (command == 'B')
                        position.yCoordinate = position.yCoordinate + 1;
                }

                if (position.Facing == 'E')
                {
                    if (command == 'F')
                        position.xCoordinate = position.xCoordinate + 1;
                    else if (command == 'B')
                        position.xCoordinate = position.xCoordinate - 1;
                }

                if (position.Facing == 'W')
                {
                    if (command == 'F')
                        position.xCoordinate = position.xCoordinate - 1;
                    else if (command == 'B')
                        position.xCoordinate = position.xCoordinate + 1;
                }

                return position;
            }
            else
                return position;
        }

    }
}
