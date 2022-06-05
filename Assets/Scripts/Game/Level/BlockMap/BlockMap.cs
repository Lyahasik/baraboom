using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Level
{
	[RequireComponent(typeof(Grid))]
	public class BlockMap : MonoBehaviour, ILevel
	{
		#region facade

		event Action ILevel.Changed
		{
			add => _changed += value;
			remove => _changed -= value;
		}

		Dictionary<Vector2Int, Block> ILevel.TopBlocks
		{
			get
			{
				var map = new Dictionary<Vector2Int, Block>();

				foreach (var layer in _layers)
				foreach (var (position, block) in layer.Blocks)
					map[position] = block;

				return map;
			}
		}

		[CanBeNull]
		Block ILevel.TopBlockAt(Vector2Int cellPosition)
		{
			foreach (var layer in _layers.Reverse())
			{
				var block = layer.BlockAt(cellPosition);
				if (block != null)
					return block;
			}

			return null;
		}

		#endregion

		#region interior

		private BlockLayer[] _layers;
		private Action _changed;

		private void Awake()
		{
			_layers = GetComponentsInChildren<BlockLayer>();
			foreach (var layer in _layers)
				layer.Changed += () => _changed?.Invoke();
		}

		#endregion
	}
}