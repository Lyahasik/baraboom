using System;
using Baraboom.Game.Level.Environment;
using UnityEngine;

namespace Baraboom.Game.Level
{
	public interface ILevel
	{
		event Action Changed;

		public ReadOnlyBlockMap BlockMap { get; }
		public void AddBot(GameObject value);
		public void RemoveBot(GameObject value);
	}
}