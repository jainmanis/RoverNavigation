using NUnit.Framework;
using PlutoRoverNavigator.Controllers;
using PlutoRoverNavigator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTest
{
    [TestFixture]
    public class TestCommands
    {
        [Test]
        public void WhenCommandSend_CheckIfValidAndExecuteCommand(
            [Values('F','A','B','C','L','R','D','G','X','Y','Z')] char inputCommand)
        {
            //char inputCommand = 'F';

            var controller = new NavigationController();
            string output = controller.ExecuteCommand(inputCommand);

            List<char> validCommands = new List<char>() { 'F', 'B', 'L', 'R' };

            if (validCommands.Contains(inputCommand))
                Assert.AreEqual("command_valid_and_executed", output);
            else
                Assert.AreEqual("invalid_command", output);
        }

        [Test]
        [TestCase(10, 10, 'N', 'F', 10, 11, 'N')]
        [TestCase(10, 10, 'N', 'X', 10, 10, 'N')]
        [TestCase(10, 11, 'N', 'B', 10, 10, 'N')]
        [TestCase(10, 10, 'S', 'F', 10, 9, 'S')]
        [TestCase(10, 10, 'W', 'B', 11, 10, 'W')]
        [TestCase(10, 10, 'E', 'F', 11, 10, 'E')]
        public void WhenForwardOrBackwardCommandSend_ReturnNewPosition(int x, int y, char facing, char command, int expX, int expY, char expFacing)
        {
            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition() {
                xCoordinate = x,
                yCoordinate = y,
                Facing = facing
            };
            
            RoverPosition result = controller.ExecuteCommand(command, currentPosition);

            Assert.AreEqual(expX, result.xCoordinate);
            Assert.AreEqual(expY, result.yCoordinate);
            Assert.AreEqual(expFacing, result.Facing);
        }

        [Test]
        [TestCase(10,10,'N', 'L', 10,10,'W')]
        [TestCase(10, 10, 'S', 'R', 10, 10, 'W')]
        [TestCase(10, 10, 'N', 'R', 10, 10, 'E')]
        public void WhenLeftOrRightCommandSend_ReturnNewPosition(int x, int y, char facing, char command, int expX, int expY, char expFacing)
        {
            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition()
            {
                xCoordinate = x,
                yCoordinate = y,
                Facing = facing
            };
            RoverPosition result = controller.ExecuteCommand(command, currentPosition);

            Assert.AreEqual(expX, result.xCoordinate);
            Assert.AreEqual(expY, result.yCoordinate);
            Assert.AreEqual(expFacing, result.Facing);
        }
    }
}
