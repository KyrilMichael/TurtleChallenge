namespace TurtleChallenge
{
	public enum Direction : byte
	{
		North = 0,
		East,
		South,
		West
	}

	public enum Result : byte
	{
		Success,
		MineHit,
		Danger,
	}
}
