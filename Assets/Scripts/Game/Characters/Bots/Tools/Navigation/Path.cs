using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools.Navigation
{
	public class Path : IEnumerable<Vector2Int>
	{
		#region facade

		public int Length => _data.Count;

		public Path(IEnumerable<Vector2Int> data)
		{
			_data = data.ToList();
		}

		IEnumerator<Vector2Int> IEnumerable<Vector2Int>.GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		public override string ToString()
		{
			return "[" + string.Join(", ", _data) + "]";
		}

		#endregion

		#region interior

		private readonly List<Vector2Int> _data;

		#endregion
	}
}