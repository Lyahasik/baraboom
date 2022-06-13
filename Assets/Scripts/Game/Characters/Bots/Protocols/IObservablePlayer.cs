using System;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IObservablePlayer
	{
		event Action PositionChanged;

		Vector2Int Position { get; }
	}
}