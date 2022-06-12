using Baraboom.Game.Characters.Bots.Tools;

namespace Baraboom.Game.Characters.Bots.States
{
	public interface IRoamingBot
	{
		WayPoint[] WayPoints { get; }
	}
}