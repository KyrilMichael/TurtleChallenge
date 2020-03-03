using System;
using System.IO;

namespace TurtleChallenge
{
	public class TurtleGame
	{
		private Settings _settings;

		public TurtleGame(string settingsFilePath)
		{
			if (string.IsNullOrWhiteSpace(settingsFilePath))
				throw new ArgumentException("Settings file path missing", nameof(settingsFilePath));

			_settings = ParseSettings(settingsFilePath);
		}

		public TurtleGame(Settings settings)
		{
			_settings = settings;
		}

		public Result GetResult(string moveSet)
		{
			var currentPos = _settings.StartingPoint;
			var currentDirection = _settings.StartingDirection;

			foreach (char action in moveSet)
			{
#if DEBUG
				Console.WriteLine($"- Current Pos ({currentPos}) - Current Dir ({currentDirection}) - Action ({action})");
#endif
				//apply action
				switch (action)
				{
					case 'M':
					case 'm':
						currentPos = Move(currentPos, currentDirection);
						break;
					case 'R':
					case 'r':
						currentDirection = Rotate(currentDirection);
						break;
					default:        //ignore any other char
						continue;
				}

#if DEBUG
				Console.WriteLine($"- - Current Pos ({currentPos}) - Current Dir ({currentDirection})");
#endif

				//check if we made it to exit point
				if (currentPos == _settings.ExitPoint)
					return Result.Success;

				//check if we hit a mine!
				if (_settings.Mines.Contains(currentPos))
					return Result.MineHit;
			}
			return Result.Danger;
		}

		public (int, int) Move((int, int) currentPosition, Direction currentDirection)
		{
			int x = currentPosition.Item1;
			int y = currentPosition.Item2;
			switch (currentDirection)
			{
				case Direction.North:
					y--;
					break;
				case Direction.East:
					x++;
					break;
				case Direction.South:
					y++;
					break;
				case Direction.West:
					x--;
					break;
			}
			if (x < 0)
				x = 0;
			else if (x == _settings.Width)
				x = _settings.Width - 1;

			if (y < 0)
				y = 0;
			else if (y == _settings.Height)
				y = _settings.Height - 1;

			return (x, y);
		}

		public Direction Rotate(Direction currentDirection)
		{
			//everytime you increment the direction variable it will go in this order North > East > South > west
			//we divide by 4 and get the reminder in case the value went above 3
			return (Direction)(((byte)currentDirection + 1) % 4);
		}

		private Settings ParseSettings(string filePath)
		{
			var lines = File.ReadAllLines(filePath);
			return new Settings(lines);
		}
	}
}
