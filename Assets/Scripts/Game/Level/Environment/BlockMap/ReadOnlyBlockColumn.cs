using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Level.Environment
{
	public class ReadOnlyBlockColumn : IReadOnlyCollection<Block>
	{
		#region facade

		public ReadOnlyBlockColumn(BlockColumn column)
		{
			_column = column;
		}

		public int Count
		{
			get => _column.Count;
		}

		public Vector2Int Position
		{
			get => _column.Position;
		}
		
		public Block Bottom
		{
			get => _column.Bottom;
		}

		public Block Top
		{
			get => _column.Top;
		}

		public Block Get(int z)
		{
			return _column.Get(z);
		}

		public IEnumerator<Block> GetEnumerator()
		{
			return _column.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		#endregion
	
		#region interior

		private readonly BlockColumn _column;

		#endregion
	}
}