using System;

namespace Baraboom.Game.Characters.Player
{
	public interface IPlayerEvents
	{
		event Action Died;
		event Action ReceivedDamage;
		event Action ReceivedPowerUp;
	}
}