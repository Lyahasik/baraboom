using System.Collections;
using System.Collections.Generic;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using IEnumerable = System.Collections.IEnumerable;

namespace Baraboom.Game.Level.Environment
{
	public class BlockMap : IEnumerable<BlockColumn>
	{
		#region facade

		public int Count
		{
			get => _columns.Count;
		}

		public ReadOnlyBlockMap AsReadOnly()
		{
			return new ReadOnlyBlockMap(this);
		}

		public BlockColumn GetColumn(Vector2Int position)
		{
			return _columns.Get(position);
		}

		public Block GetBlock(Vector3Int position)
		{
			return _columns.Get(position.XY())?.Get(position.z);
		}

		public void AddBlock(Block block)
		{
			var columnPosition = block.DiscretePosition.XY();
			_columns.GetOrInit(columnPosition, () => new BlockColumn(columnPosition)).Add(block);
		}

		public void RemoveBlock(Block block)
		{
			var blockXY = block.DiscretePosition.XY();

			if (_columns.TryGetValue(blockXY, out var column))
			{
				column.Remove(block);
				if (column.Count == 0)
					_columns.Remove(blockXY);
			}
		}

		public IEnumerator<BlockColumn> GetEnumerator()
		{
			return _columns.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region interior

		private readonly Dictionary<Vector2Int, BlockColumn> _columns = new();

		#endregion
	}
}