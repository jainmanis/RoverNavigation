using NUnit.Framework;
using PlutoRoverNavigator.Controllers;
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
    }
}
