using UnityEngine;

namespace Baraboom.Game.Tools.Extensions
{
	public static class ExtensionVector3Int
	{
		public static Vector2Int Make2D(this Vector3Int @this)
		{
			return new Vector2Int(@this.x, @this.y);
		}
	}
}