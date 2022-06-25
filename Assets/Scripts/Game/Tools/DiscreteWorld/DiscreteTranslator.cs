using UnityEngine;

namespace Baraboom.Game.Tools.DiscreteWorld
{
	public static class DiscreteTranslator
	{
		public static Vector2 ToContinuous(Vector2Int value)
		{
			return new Vector2(value.x + 0.5f, value.y + 0.5f);
		}

		public static Vector3 ToContinuous(Vector3Int value)
		{
			return new Vector3(value.x + 0.5f, value.y + 0.5f, value.z);
		}

		public static Vector3Int ToDiscrete(Vector3 value)
		{
			return new Vector3Int(Mathf.FloorToInt(value.x), Mathf.FloorToInt(value.y), Mathf.FloorToInt(value.z));
		}
	}
}