using System;

namespace TurtleChallenge
{
	public static class Extensions
	{
		public static string TrimComments(this string str)
		{
			return str.Split("--")[0];
		}

		public static (int, int) ParsePoint(this string str)
		{
			var pointParts = str.TrimComments().Split(',');
			return (int.Parse(pointParts[0]), int.Parse(pointParts[1]));
		}

		public static Direction ParseDirection(this string str)
		{
			str = str.Trim();
			switch (str)
			{
				case "N":
				case "n":
					return Direction.North;
				case "E":
				case "e": 
					return Direction.East;
				case "S":
				case "s":
					return Direction.South;
				case "W":
				case "w":
					return Direction.West;
				default:
					throw new ArgumentException($"Can't parse direction {str}", nameof(str));
			}
		}
	}
}
