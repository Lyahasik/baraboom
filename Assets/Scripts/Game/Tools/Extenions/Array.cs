namespace Baraboom.Game.Tools.Extensions
{
	public static class Array
	{
		public static int LoopIncrement(int current, int length)
		{
			return current < length - 1 ? current + 1 : 0;
		}
	}
}