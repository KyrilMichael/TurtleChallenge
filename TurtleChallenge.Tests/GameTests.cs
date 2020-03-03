using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace TurtleChallenge.Tests
{
	public class GameTests
	{
		[Test]
		public void Move_OutOfBounds_Test()
		{
			//Arrange
			var currentPos = (0, 1);
			var currentDir = Direction.West;

			var game = new TurtleGame(new Settings(5, 4, currentPos, currentDir, (3, 0), new List<(int, int)>()));
			//Act
			var position = game.Move(currentPos, currentDir);
			//Assert
			Assert.AreEqual(position, currentPos);
		}

		[TestCase(Direction.North, ExpectedResult = Direction.East)]
		[TestCase(Direction.East, ExpectedResult = Direction.South)]
		[TestCase(Direction.South, ExpectedResult = Direction.West)]
		[TestCase(Direction.West, ExpectedResult = Direction.North)]
		public Direction Rotate_Test(Direction currentDir)
		{
			//Arrange
			var game = new TurtleGame(new Settings(5, 4, (0, 0), currentDir, (3, 0), new List<(int, int)>()));

			//Act
			return game.Rotate(currentDir);
		}
	}
}
