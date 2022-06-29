using UnityEngine;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionVector3
	{
		public static Vector3 WithZ(this Vector3 @this, float z)
		{
			return new Vector3(@this.x, @this.y, z);
		}
	}
}