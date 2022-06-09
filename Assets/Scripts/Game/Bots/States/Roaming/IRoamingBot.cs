namespace Baraboom.Game.Bots.States
{
	public interface IRoamingBot : IControllableBot
	{
		WayPoint[] WayPoints { get; }
	}
}