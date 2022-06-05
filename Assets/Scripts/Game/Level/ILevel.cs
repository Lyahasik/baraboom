using System;
using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Level
{
	public interface ILevel
	{
		event Action Changed;

		public Dictionary<Vector2Int, Block> TopBlocks { get; }

		public Block TopBlockAt(Vector2Int cellPosition);
	}
}