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
        public void WhenForwardOrBackwardCommandSend_ReturnNewPosition()
        {
            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition() {
                xCoordinate = 10,
                yCoordinate = 10,
                Facing = 'N'
            };

            //Forward command facing North
            RoverPosition newPosition = controller.ExecuteCommand('F', currentPosition);

            Assert.AreEqual(10, newPosition.xCoordinate);
            Assert.AreEqual(11, newPosition.yCoordinate);
            Assert.AreEqual('N', newPosition.Facing);

            //Invalid command
            RoverPosition newPosition2 = controller.ExecuteCommand('X', newPosition);

            Assert.AreEqual(10, newPosition2.xCoordinate);
            Assert.AreEqual(11, newPosition2.yCoordinate);
            Assert.AreEqual('N', newPosition2.Facing);

            //Backward command facing north
            RoverPosition newPosition3 = controller.ExecuteCommand('B', newPosition2);

            Assert.AreEqual(10, newPosition3.xCoordinate);
            Assert.AreEqual(10, newPosition3.yCoordinate);
            Assert.AreEqual('N', newPosition3.Facing);


            //Forward command facing South
            currentPosition = new RoverPosition()
            {
                xCoordinate = 10,
                yCoordinate = 10,
                Facing = 'S'
            };
            RoverPosition newPosition4 = controller.ExecuteCommand('F', currentPosition);

            Assert.AreEqual(10, newPosition4.xCoordinate);
            Assert.AreEqual(9, newPosition4.yCoordinate);
            Assert.AreEqual('S', newPosition4.Facing);


            //Backward command facing West
            currentPosition = new RoverPosition()
            {
                xCoordinate = 10,
                yCoordinate = 10,
                Facing = 'W'
            };
            RoverPosition newPosition5 = controller.ExecuteCommand('B', currentPosition);

            Assert.AreEqual(11, newPosition5.xCoordinate);
            Assert.AreEqual(10, newPosition5.yCoordinate);
            Assert.AreEqual('W', newPosition5.Facing);

            //Forward command facing East
            currentPosition = new RoverPosition()
            {
                xCoordinate = 10,
                yCoordinate = 10,
                Facing = 'E'
            };
            RoverPosition newPosition6 = controller.ExecuteCommand('F', currentPosition);

            Assert.AreEqual(11, newPosition6.xCoordinate);
            Assert.AreEqual(10, newPosition6.yCoordinate);
            Assert.AreEqual('E', newPosition6.Facing);
        }
    }
}
