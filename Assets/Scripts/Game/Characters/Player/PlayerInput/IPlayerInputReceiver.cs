using UnityEngine;

namespace Baraboom.Game.Characters.Player.PlayerInput
{
	public interface IPlayerInputReceiver
	{
		Vector2Int Movement { get; }

		bool Bomb { get; }
	}
}