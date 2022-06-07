using UnityEngine;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Game.Bots.Tools.PathFinder
{
	public class BlockDescriptor : AStar.INode
	{
		public Vector2Int Position { get; }
		public bool IsWalkable { get; }

		public BlockDescriptor(Vector2Int position, bool isWalkable)
		{
			Position = position;
			IsWalkable = isWalkable;
		}

		public override bool Equals(object that)
		{
			if (that is BlockDescriptor thatBlockDescriptor)
				return this.Position == thatBlockDescriptor.Position;

			return false;
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode();
		}
	}
}