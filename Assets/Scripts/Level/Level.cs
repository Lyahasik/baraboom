using UnityEngine;

namespace Baraboom.Level
{
	[RequireComponent(typeof(BlockMap))]
	public class Level : MonoBehaviour, ILevel
	{
		#region facade

		Vector3Int ILevel.WorldToCell(Vector3 position)
		{
			return _map.WorldToCell(position);
		}
		
		Block ILevel.GetTopBlock(Vector3Int cellPosition)
		{
			return _map.GetTopBlock(cellPosition);
		}
		
		#endregion

		#region interior

		private BlockMap _map;

		private void Awake()
		{
			_map = GetComponent<BlockMap>();
		}

		#endregion
	}
}