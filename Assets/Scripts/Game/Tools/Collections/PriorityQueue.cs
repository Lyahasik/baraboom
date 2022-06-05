using System;
using System.Collections.Generic;
using System.Linq;

namespace Baraboom.Game.Tools.Collections
{
	public class PriorityQueue<T>
	{
		#region facade

		public int Count { get; private set; }

		public void Enqueue(T element, float priority)
		{
			if (!_data.TryGetValue(priority, out var elements))
				elements = _data[priority] = new LinkedList<T>();

			elements.AddLast(element);
			Count++;

			_lookUp[element] = priority;
		}

		public bool TryDequeue(out T result)
		{
			if (_data.Count == 0)
			{
				result = default;
				return false;
			}

			result = Dequeue();
			return true;
		}

		public T Dequeue()
		{
			if (_data.Count == 0)
				throw new InvalidOperationException("Queue is empty");

			var (minKey, minKeyElements) = _data.First();

			var minElement = minKeyElements.First();
			minKeyElements.RemoveFirst();

			if (minKeyElements.Count == 0)
				_data.Remove(minKey);

			_lookUp.Remove(minElement);

			Count--;
			return minElement;
		}

		public bool Remove(T element)
		{
			if (!_lookUp.TryGetValue(element, out var priority))
				return false;

			_lookUp.Remove(element);
			return _data[priority].Remove(element);
		}

		public bool Find(T element, out T result)
		{
			if (!_lookUp.TryGetValue(element, out var priority))
			{
				result = default;
				return false;
			}

			
			var node = _data[priority].Find(element);
			if (node == null)
			{
				result = default;
				return false;
			}

			result = node.Value;
			return true;
		}

		#endregion

		#region interior

		private readonly SortedDictionary<float, LinkedList<T>> _data = new ();
		private readonly Dictionary<T, float> _lookUp = new ();

		#endregion
	}
}