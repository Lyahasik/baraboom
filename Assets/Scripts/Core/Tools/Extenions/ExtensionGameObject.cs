using UnityEngine;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionGameObject
	{
		public static GameObject AddChild(this GameObject @this, string name)
		{
			var child = new GameObject(name);
			child.transform.parent = @this.transform;

			return child;
		}
	}
}