using UnityEngine;
using Zenject;

namespace Baraboom.Game.Tools.DI
{
	public class PrefabFactoryWithPosition<T> : IFactory<Object, Vector3, T>
	{
		#region facade

		public PrefabFactoryWithPosition(DiContainer container)
		{
			_container = container;
		}

		public T Create(Object prefab, Vector3 position)
		{
			var instance = _container.InstantiatePrefab(prefab, position, Quaternion.identity, null);
			return instance.GetComponent<T>();
		}

		#endregion

		#region interior

		private readonly DiContainer _container;

		#endregion
	}
}