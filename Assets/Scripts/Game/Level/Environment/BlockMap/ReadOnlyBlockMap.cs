using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Level.Environment
{
	public class ReadOnlyBlockMap : IReadOnlyCollection<ReadOnlyBlockColumn>
	{
		#region facade

		public ReadOnlyBlockMap(BlockMap map)
		{
			_map = map;
		}

		public int Count
		{
			get => _map.Count;
		}

		public BlockColumn GetColumn(Vector2Int position)
		{
			return _map.GetColumn(position);
		}

		public Block GetBlock(Vector3Int position)
		{
			return _map.GetBlock(position);
		}
		
		public IEnumerator<ReadOnlyBlockColumn> GetEnumerator()
		{
			return _map.Select(column => column.AsReadOnly()).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
		
		#region interior

		private readonly BlockMap _map;

		#endregion
	}
}