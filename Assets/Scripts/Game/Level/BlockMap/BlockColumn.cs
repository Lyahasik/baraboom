using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using IEnumerable = System.Collections.IEnumerable;

namespace Baraboom.Game.Level
{
	public class BlockColumn : IEnumerable<Block>
	{
		#region facade

		public BlockColumn(Vector2Int position)
		{
			_position = position;
			_blocks = new SortedDictionary<int, Block>(Comparer<int>.Create((x, y) => y - x));
		}

		public int Count
		{
			get => _blocks.Count;	
		}

		public Vector2Int Position
		{
			get => _position;
		}

		public Block Bottom
		{
			get => _blocks.Values.First();
		}

		public Block Top
		{
			get => _blocks.Values.Last();
		}

		public ReadOnlyBlockColumn AsReadOnly()
		{
			return new ReadOnlyBlockColumn(this);
		}

		public Block Get(int z)
		{
			return _blocks.Get(z);
		}

		public void Add(Block block)
		{
			_blocks[block.DiscretePosition.z] = block;
		}

		public void Remove(Block block)
		{
			_blocks.Remove(block.DiscretePosition.z);
		}

		public IEnumerator<Block> GetEnumerator()
		{
			return _blocks.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region interior

		private readonly Vector2Int _position;
		private readonly SortedDictionary<int, Block> _blocks;

		#endregion
	}
}