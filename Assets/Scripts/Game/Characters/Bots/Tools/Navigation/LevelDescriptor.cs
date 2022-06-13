using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Level;
using Baraboom.Game.Level.Environment;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Game.Characters.Bots.Tools.Navigation
{
	public class LevelDescriptor : AStar.IGraph<BlockDescriptor>
	{
		#region facade

		public LevelDescriptor(ReadOnlyBlockMap blockMap)
		{
			_blocksByPosition = blockMap.ToDictionary(
				column => column.Position,
				column => new BlockDescriptor(column.Position, column.Top is Ground)
			);
		}

		public BlockDescriptor GetBlock(Vector2Int position)
		{
			return _blocksByPosition.Get(position);
		}

		IEnumerable<BlockDescriptor> AStar.IGraph<BlockDescriptor>.GetNeighbors(BlockDescriptor node)
		{
			foreach (var neighborsOffsets in NeighborsOffsets)
			{
				if (_blocksByPosition.TryGetValue(node.Position + neighborsOffsets, out var neighbor) && neighbor.IsWalkable)
					yield return neighbor;
			}
		}

		#endregion

		#region interior

		private static IEnumerable<Vector2Int> NeighborsOffsets
		{
			get
			{
				yield return Vector2Int.up;
				yield return Vector2Int.down;
				yield return Vector2Int.left;
				yield return Vector2Int.right;
			}
		}

		private readonly Dictionary<Vector2Int, BlockDescriptor> _blocksByPosition;

		#endregion
	}
}