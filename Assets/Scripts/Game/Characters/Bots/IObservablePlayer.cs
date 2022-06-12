using System;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots
{
	public interface IObservablePlayer
	{
		event Action PositionChanged;

		Vector2Int Position { get; }
	}
}