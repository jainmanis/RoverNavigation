using PlutoRoverNavigator.Models;

namespace PlutoRoverNavigator.Utilities.Helper
{
    public class Wrapper
    {
        //considering 100 * 100 Grid [0-99]
        private const int minGridCordinateX = 0;
        private const int maxGridCordinateX = 99;
        private const int minGridCordinateY = 0;
        private const int maxGridCordinateY = 99;

        public static RoverPosition ApplyWrapperToPosition(RoverPosition position)
        {
            if (position.yCoordinate > maxGridCordinateY)
                position.yCoordinate = minGridCordinateY;
            else if (position.yCoordinate < minGridCordinateY)
                position.yCoordinate = maxGridCordinateY;
            else if (position.xCoordinate < minGridCordinateX)
                position.xCoordinate = maxGridCordinateX;
            else if (position.xCoordinate > maxGridCordinateX)
                position.xCoordinate = minGridCordinateX;

            return position;

        }
    }
}