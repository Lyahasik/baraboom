using System;
using System.Collections.Generic;

namespace Baraboom.Game.Tools.Collections
{
	public class BouncingIterator<T>
	{
		#region facade

		public BouncingIterator(IList<T> collection, int startIndex = 0)
		{
			_collection = collection;
			_nextIndex = startIndex;
			_step = 1;
		}

		public T Next
		{
			get
			{
				if (_collection.Count == 0)
					throw new InvalidOperationException("Sequence contains no elements");

				// This operations helps in two cases:
				//   1. Collection contains only one element, so index can't be incremented.
				//   2. Collection size have changed since last call. 
				_nextIndex = Math.Min(_nextIndex, _collection.Count);

				var currentIndex = _nextIndex;

				if (_nextIndex == _collection.Count - 1)
					_step = -1;
				if (_nextIndex == 0)
					_step = +1;
				_nextIndex += _step;

				return _collection[currentIndex];
			}
		}

		#endregion

		#region interior

		private readonly IList<T> _collection;
		private int _nextIndex;
		private int _step;

		#endregion
	}
}