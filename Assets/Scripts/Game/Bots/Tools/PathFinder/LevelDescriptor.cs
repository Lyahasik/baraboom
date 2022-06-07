using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Level;
using UnityEngine;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Game.Bots.Tools.PathFinder
{
	public class LevelDescriptor : AStar.IGraph<BlockDescriptor>
	{
		#region facade

		public LevelDescriptor(Dictionary<Vector2Int, Block> reference)
		{
			_blocksByPosition = reference.ToDictionary(
				entry => entry.Key,
				entry => new BlockDescriptor(entry.Key, entry.Value is Ground)
			);
		}

		public BlockDescriptor FindBlock(Vector2Int position)
		{
			return _blocksByPosition[position];
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