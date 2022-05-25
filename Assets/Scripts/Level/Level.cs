using UnityEngine;

namespace Baraboom.Level
{
	[RequireComponent(typeof(BlockMap))]
	public class Level : MonoBehaviour
	{
		#region facade

		public Vector3Int WorldToCell(Vector3 position)
		{
			return _map.WorldToCell(position);
		}
		
		public Block GetTopBlock(Vector3Int cellPosition)
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