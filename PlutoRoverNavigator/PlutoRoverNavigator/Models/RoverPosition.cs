using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlutoRoverNavigator.Models
{
    public class RoverPosition
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public char Facing { get; set; }

        public bool ObstaclePresent { get; set; }

        public RoverPosition()
        {
            xCoordinate = 0;
            yCoordinate = 0;
            Facing = 'N';

            ObstaclePresent = false;
        }
    }
}