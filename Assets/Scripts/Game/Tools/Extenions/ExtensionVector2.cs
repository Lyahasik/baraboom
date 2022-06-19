using UnityEngine;

namespace Baraboom.Game.Tools.Extensions
{
	public static class ExtensionExtensionVector2
	{
		public static Vector3 WithZ(this Vector2 @this, float z)
		{
			return new Vector3(@this.x, @this.y, z);
		}
	}
}