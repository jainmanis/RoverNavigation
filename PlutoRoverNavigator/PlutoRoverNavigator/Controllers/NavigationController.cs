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
        public RoverPosition GetPosition()
        {
            return new RoverPosition();
        }

        public string ExecuteCommand(char command)
        {
            if (command == 'F' || command == 'B' || command == 'L' || command == 'R')
                return "command_valid_and_executed";
            else
                return "invalid_command";
        }
    }
}
