using UnityEngine;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionVector3Int
	{
		public static Vector2Int XY(this Vector3Int @this)
		{
			return new Vector2Int(@this.x, @this.y);
		}
	}
}