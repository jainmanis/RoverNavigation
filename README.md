# RoverNavigation

Navigation service for Pluto Rover


To simplify navigation, the planet has been divided up into a grid. The rover's position and
location is represented by a combination of x and y coordinates and a letter representing one
of the four cardinal compass points. An example position might be 0, 0, N, which means the
rover is in the bottom left corner and facing North. Assume that the square directly North
from (x, y) is (x, y+1).

In order to control a rover, NASA sends a simple string of letters. The only commands you
can give the rover are ‘F’,’B’,’L’ and ‘R’

Commands (‘F’,’B’) moves the rover forward/backward by one grid point, and maintain the same heading.

Commands (‘L’,’R’) make the rover spin 90 degrees left or right respectively, without moving from its current spot.

Wrapping is done from one edge of the grid to another. Considering a grid of 100 x 100.

Obstacle detection before each move to a new square is done. If a given sequence of commands encounters an obstacle, the rover moves up to the last
possible point and reports the obstacle.

Just build the solution and run the tests and remember to restore the nuget packages.