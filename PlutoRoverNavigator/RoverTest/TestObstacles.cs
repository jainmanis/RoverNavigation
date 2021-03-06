﻿using NUnit.Framework;
using PlutoRoverNavigator.Controllers;
using PlutoRoverNavigator.Models;
using System;
using System.Collections.Generic;

namespace RoverTest
{
    [TestFixture]
    public class TestObstacles
    {
        [Test]
        [TestCase(0, 0, 'E', 'F',0, 0, 'E', true)]
        [TestCase(1, 1, 'N', 'F', 1, 1, 'N', false)]
        [TestCase(5, 4, 'N', 'F', 5, 4, 'N', true)]
        [TestCase(10, 10, 'S', 'B', 10, 10, 'S', false)]
        public void CheckIfObstaclePresentForMovingCommands_WithoutMoving(int x, int y, char facing, char command, int expX, int expY, char expFacing, bool expObstacle)
        {
            List<Tuple<int, int>> Obstacles = new List<Tuple<int, int>>();
            Obstacles.Add(new Tuple<int, int>(1, 0));
            Obstacles.Add(new Tuple<int, int>(5, 5));

            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition()
            {
                xCoordinate = x,
                yCoordinate = y,
                Facing = facing
            };

            RoverPosition result = controller.CheckObstacle(false, command, currentPosition, Obstacles);

            Assert.AreEqual(expX, result.xCoordinate);
            Assert.AreEqual(expY, result.yCoordinate);
            Assert.AreEqual(expFacing, result.Facing);
            Assert.AreEqual(expObstacle, result.ObstaclePresent);
        }

        [Test]
        [TestCase(0, 0, 'E', 'F', 0, 0, 'E', true)]
        [TestCase(1, 1, 'N', 'F', 1, 2, 'N', false)]
        [TestCase(5, 4, 'N', 'F', 5, 4, 'N', true)]
        [TestCase(10, 10, 'S', 'B', 10, 11, 'S', false)]
        [TestCase(99, 99, 'N', 'F', 99, 0, 'N', false)]
        public void CheckIfObstaclePresentForMovingCommands_WithMovingIfNoObstacleFound(int x, int y, char facing, char command, int expX, int expY, char expFacing, bool expObstacle)
        {
            List<Tuple<int, int>> Obstacles = new List<Tuple<int, int>>();
            Obstacles.Add(new Tuple<int, int>(1, 0));
            Obstacles.Add(new Tuple<int, int>(5, 5));

            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition()
            {
                xCoordinate = x,
                yCoordinate = y,
                Facing = facing
            };

            RoverPosition result = controller.ExecuteCommand(command.ToString(), currentPosition, Obstacles);

            Assert.AreEqual(expX, result.xCoordinate);
            Assert.AreEqual(expY, result.yCoordinate);
            Assert.AreEqual(expFacing, result.Facing);
            Assert.AreEqual(expObstacle, result.ObstaclePresent);
        }

        [Test]
        [TestCase(2, 2, 'N', "FFRFFR", 3, 4, 'E', true)]
        [TestCase(2, 2, 'N', "FFRFRF", 3, 3, 'S', false)]
        [TestCase(10, 10, 'E', "LFFLFFL", 8, 12, 'S', false)]
        [TestCase(45, 25, 'S', "LLFFLBBBFF", 47, 27, 'W', true)]
        public void CheckWithMultipleCommands_ObstacleDetectionAndMovingUntilLastSquareAvailable(int x, int y, char facing, string command, int expX, int expY, char expFacing, bool expObstacle)
        {
            List<Tuple<int, int>> Obstacles = new List<Tuple<int, int>>();
            Obstacles.Add(new Tuple<int, int>(4, 4));
            Obstacles.Add(new Tuple<int, int>(5, 5));
            Obstacles.Add(new Tuple<int, int>(48, 27));

            var controller = new NavigationController();
            RoverPosition currentPosition = new RoverPosition()
            {
                xCoordinate = x,
                yCoordinate = y,
                Facing = facing
            };

            RoverPosition result = controller.ExecuteCommand(command.ToString(), currentPosition, Obstacles);

            Assert.AreEqual(expX, result.xCoordinate);
            Assert.AreEqual(expY, result.yCoordinate);
            Assert.AreEqual(expFacing, result.Facing);
            Assert.AreEqual(expObstacle, result.ObstaclePresent);
        }
    }
}
