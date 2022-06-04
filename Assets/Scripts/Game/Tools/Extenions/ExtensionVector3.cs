using UnityEngine;

namespace Baraboom.Game.Tools
{
	public static class ExtensionVector3
	{
		public static Vector3 WithX(this Vector3 @this, float x)
		{
			return new Vector3(x, @this.y, @this.z);
		}

		public static Vector3 WithY(this Vector3 @this, float y)
		{
			return new Vector3(@this.x, y, @this.z);
		}

		public static Vector3 WithZ(this Vector3 @this, float z)
		{
			return new Vector3(@this.x, @this.y, z);
		}
	}
}