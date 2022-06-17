using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IEnumerable = System.Collections.IEnumerable;

namespace Baraboom.Game.Tools.Collections
{
	public class MultiDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
	{
		#region facade

		public IEnumerable<TValue> Get(TKey key)
		{
			if (_data.TryGetValue(key, out var list))
				return list;

			return Enumerable.Empty<TValue>();
		}

		public void Add(TKey key, TValue value)
		{
			if (!_data.TryGetValue(key, out var list))
				list = _data[key] = new List<TValue>();
			list.Add(value);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			foreach (var (key, list) in _data)
			foreach (var value in list)
				yield return new KeyValuePair<TKey, TValue>(key, value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region interior

		private readonly Dictionary<TKey, List<TValue>> _data = new();

		#endregion
	}
}