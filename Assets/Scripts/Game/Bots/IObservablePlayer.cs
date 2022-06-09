using System;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	public interface IObservablePlayer
	{
		event Action PositionChanged;

		Vector2Int Position { get; }
	}
}