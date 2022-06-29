using UnityEngine;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionVector2
	{
		public static Vector2 WithX(this Vector2 @this, float x)
		{
			return new Vector2(x, @this.y);
		}

		public static Vector2 WithY(this Vector2 @this, float y)
		{
			return new Vector2(@this.x, y);
		}

		public static Vector3 WithZ(this Vector2 @this, float z)
		{
			return new Vector3(@this.x, @this.y, z);
		}
	}
}