using UnityEngine;
using Zenject;

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

			_factory.Create(item, transform.position);
		}

		#endregion

		#region interior

		[SerializeField] private float _probability;

		[Inject] private ItemStore _store;
		[Inject] private IFactory<Object, Vector3, Item> _factory;

		#endregion
	}
}