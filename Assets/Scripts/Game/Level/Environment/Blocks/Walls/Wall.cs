namespace Baraboom.Game.Level.Environment
{
	public abstract class Wall : Block
	{
		public sealed override bool IsWalkable => false;
	}
}