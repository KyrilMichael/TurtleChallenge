using NUnit.Framework;
using System;

namespace TurtleChallenge.Tests
{
	public class ExtensionsTests
	{
		[Test]
		public void TrimComments_Tests_WithComments()
		{
			//AAA
			//Arrange
			var testString = "5--comment";
			//Act
			var result = testString.TrimComments();
			//Assert
			Assert.AreEqual("5", result);
		}

		[Test]
		public void TrimComments_Tests_WithoutComments()
		{
			//AAA
			//Arrange
			var testString = "5";
			//Act
			var result = testString.TrimComments();
			//Assert
			Assert.AreEqual("5", result);
		}

		[Test]
		public void ParsePoint_Tests_WithComments()
		{
			//AAA
			//Arrange
			var testString = "0,0--comment";
			//Act
			var result = testString.ParsePoint();
			//Assert
			Assert.AreEqual((0, 0), result);
		}

		[Test]
		public void ParsePoint_Tests_WithoutComments()
		{
			//AAA
			//Arrange
			var testString = "0,0";
			//Act
			var result = testString.ParsePoint();
			//Assert
			Assert.AreEqual((0, 0), result);
		}

		[TestCase("N", ExpectedResult = Direction.North)]
		[TestCase("n", ExpectedResult = Direction.North)]
		[TestCase("E", ExpectedResult = Direction.East)]
		[TestCase("e", ExpectedResult = Direction.East)]
		[TestCase("S", ExpectedResult = Direction.South)]
		[TestCase("s", ExpectedResult = Direction.South)]
		[TestCase("W", ExpectedResult = Direction.West)]
		[TestCase("w", ExpectedResult = Direction.West)]
		public Direction ParseDirection_Success(string testString)
		{
			return testString.ParseDirection();
		}

		[Test]
		public void ParseDirection_Failure()
		{
			//AAA
			//Arrange
			var testString = "q";
			//Act
			//Assert
			Assert.Throws(typeof(ArgumentException), () => testString.ParseDirection());
		}
	}
}
