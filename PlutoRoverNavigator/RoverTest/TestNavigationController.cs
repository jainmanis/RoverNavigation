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
    public class TestNavigationController
    {
        [Test]
        public void GetPosition_ShouldReturnPosition()
        {
            var controller = new NavigationController();
            RoverPosition result = controller.GetPosition();

            RoverPosition expected = new RoverPosition() {
                xCoordinate = 0,
                yCoordinate = 0,
                Facing = 'N'
            };

            Assert.AreEqual(expected.xCoordinate, result.xCoordinate);
            Assert.AreEqual(expected.yCoordinate, result.yCoordinate);
            Assert.AreEqual(expected.Facing, result.Facing);
        }
    }
}
