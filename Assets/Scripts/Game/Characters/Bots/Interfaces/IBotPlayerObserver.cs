namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IBotPlayerObserver
	{
		bool IsPlayerReachable { get; }

		bool IsPlayerVisible { get; }
	}
}