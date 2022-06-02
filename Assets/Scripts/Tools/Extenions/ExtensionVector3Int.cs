using UnityEngine;

namespace Tools
{
	public static class ExtensionVector3Int
	{
		// ReSharper disable once InconsistentNaming
		public static Vector2Int xy(this Vector3Int @this)
		{
			return new Vector2Int(@this.x, @this.y);
		}
	}
}