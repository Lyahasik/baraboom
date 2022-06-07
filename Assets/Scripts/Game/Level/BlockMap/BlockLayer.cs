using System;
using System.Collections.Generic;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Level
{
	public class BlockLayer : MonoBehaviour
	{
		#region facade

		public event Action Changed;

		public Dictionary<Vector2Int, Block> Blocks => _blocks;

		[CanBeNull]
		public Block BlockAt(Vector2Int cellPosition)
		{
			return _blocks.TryGetValue(cellPosition, out var result) ? result : null;
		}

		#endregion

		#region interior

		private readonly Dictionary<Vector2Int, Block> _blocks = new();

		private void Awake()
		{
			for (var i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				var position = DiscreteTranslator.ToDiscrete(child.transform.position).Make2D();

				_blocks[position] = child.GetComponent<Block>();
				_blocks[position].Destroyed += () =>
				{
					_blocks.Remove(position);
					Changed?.Invoke();
				};
			}
		}

		#endregion
	}
}