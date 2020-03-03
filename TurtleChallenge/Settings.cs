using System.Collections.Generic;

namespace TurtleChallenge
{
	public class Settings
	{
		public int Width { get; }
		public int Height { get; }
		public (int, int) StartingPoint { get; }
		public Direction StartingDirection { get; }
		public (int, int) ExitPoint { get; }

		public List<(int, int)> Mines { get; }

		public Settings(string[] fileLines)
		{
			Width = int.Parse(fileLines[0].TrimComments());
			Height = int.Parse(fileLines[1].TrimComments());

			var startingPos = fileLines[2].TrimComments().Split(',');
			StartingPoint = (int.Parse(startingPos[0]), int.Parse(startingPos[1]));
			StartingDirection = startingPos[2].ParseDirection();

			ExitPoint = fileLines[3].ParsePoint();

			Mines = new List<(int, int)>();
			for (int i = 4; i < fileLines.Length; i++)
			{
				Mines.Add(fileLines[i].ParsePoint());
			}
		}

		public Settings(int width, int height, (int, int) startingPoint, Direction startingDirection, (int, int) exitPoint, List<(int, int)> mines)
		{
			Width = width;
			Height = height;
			StartingPoint = startingPoint;
			StartingDirection = startingDirection;
			ExitPoint = exitPoint;
			Mines = mines;
		}
	}
}
