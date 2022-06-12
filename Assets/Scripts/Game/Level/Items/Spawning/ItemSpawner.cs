using UnityEngine;

namespace Baraboom.Game.Level.Items
{
	public class ItemSpawner : MonoBehaviour, IItemSpawner
	{
		#region facade

		void IItemSpawner.TrySpawn()
		{
			if (Random.Range(0, 1.0f) > _probability)
				return;

			var item = _store.TryGetRandomItem();
			if (item == null)
				return;

			Instantiate(item, transform.position, Quaternion.identity);
		}

		#endregion

		#region interior

		[SerializeField] private float _probability;

		private ItemStore _store;

		private void Awake()
		{
			_store = GameObject.Find("ItemStore").GetComponent<ItemStore>(); // TODO Injection
		}

		#endregion
	}
}