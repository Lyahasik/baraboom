using System;
using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Protocols
{
	public interface IObservablePlayer : IUnityObject
	{
		event Action PositionChanged;

		Vector3Int Position { get; }
	}
}