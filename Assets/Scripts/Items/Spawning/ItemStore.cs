using System.Collections.Generic;
using UnityEngine;

namespace Baraboom
{
	public class ItemStore : MonoBehaviour
	{
		#region facade

		public Item TryGetRandomItem()
		{
			if (_items.Count == 0)
				return null;

			var index = Random.Range(0, _items.Count);
			var description = _items[index];

			description.Quantity--;
			if (description.Quantity == 0)
				_items.RemoveAt(index);

			return description.Item;
		}

		#endregion

		#region interior

		[System.Serializable]
		public class ItemDescription
		{
			public Item Item;
			public int Quantity;
		}

		[SerializeField, NonReorderable] private List<ItemDescription> _items;

		#endregion		
	}
}