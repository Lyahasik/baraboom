using UnityEngine;

namespace Baraboom.Level
{
	[RequireComponent(typeof(BlockMap))]
	public class Level : MonoBehaviour, ILevel
	{
		#region facade

		Block ILevel.GetTopBlock(Vector2Int cellPosition)
		{
			return _blocks.GetTopBlock(cellPosition);
		}

		#endregion

		#region interior

		private BlockMap _blocks;

		private void Awake()
		{
			_blocks = GetComponent<BlockMap>();
		}

		#endregion
	}
}