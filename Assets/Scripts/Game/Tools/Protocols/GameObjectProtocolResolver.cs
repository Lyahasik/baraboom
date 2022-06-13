using System;
using System.Linq;
using UnityEngine;

namespace Baraboom.Game.Tools.Protocols
{
	public class GameObjectProtocolResolver : IProtocolResolver
	{
		#region facade

		public GameObjectProtocolResolver(GameObject @object)
		{
			_objectName = @object.name;
			_components = @object.GetComponents<Component>();
		}

		T IProtocolResolver.Resolve<T>()
		{
			var protocol = FindComponent<T>();
			if (protocol == null)
				throw new Exception($"Can't resolve protocol '{typeof(T)}' on game object '{_objectName}'");

			return protocol;
		}

		T IProtocolResolver.TryResolve<T>()
		{
			return FindComponent<T>();
		}

		#endregion

		#region interior

		private readonly string _objectName;
		private readonly Component[] _components;

		private T FindComponent<T>()
		{
			return _components.OfType<T>().FirstOrDefault();
		}

		#endregion
	}
}