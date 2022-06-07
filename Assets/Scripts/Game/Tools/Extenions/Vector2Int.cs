using UnityEngine;

namespace Baraboom.Game.Tools.Extensions
{
	public static class ExtensionVector2Int
	{
		public static Vector3Int Make3D(this Vector2Int @this, int z)
		{
			return new Vector3Int(@this.x, @this.y, z);
		}
	}
}