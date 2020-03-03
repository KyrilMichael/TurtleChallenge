using System;
using System.IO;

namespace TurtleChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Please specify the settings file and the moves file as program arguments.");
				return;
			}
#if DEBUG
			var settingsFile = args.Length > 0 ? args[0] : "game-settings.txt";
			var movesFilePath = args.Length > 1 ? args[1] : "moves.txt";
#else
			var settingsFile = args[0];
			var movesFilePath = args[1];
#endif
			if (string.IsNullOrWhiteSpace(movesFilePath))
				throw new ArgumentException("Moves file path missing", nameof(movesFilePath));

			var game = new TurtleGame(settingsFile);

			var moves = ParseMoves(movesFilePath);

			for (int i = 0; i < moves.Length; i++)
			{
				var moveSet = moves[i];
				var result = game.GetResult(moveSet);

				Console.WriteLine($"Sequence {i + 1}: {result}!.");
			}
#if DEBUG
			//Press any key to Exit
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
#endif
		}

		static string[] ParseMoves(string movesFilePath)
		{
			return File.ReadAllLines(movesFilePath);
		}
	}
}
