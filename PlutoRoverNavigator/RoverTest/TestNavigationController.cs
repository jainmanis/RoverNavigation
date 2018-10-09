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
    public class TestNavigationController
    {
        [Test]
        public void GetPosition_ShouldReturnPosition()
        {
            var controller = new NavigationController();
            string result = controller.GetPosition();

            Assert.AreEqual("Start", result);
        }
    }
}
