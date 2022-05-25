using System.Linq;
using UnityEngine;

namespace Baraboom.Level
{
	[RequireComponent(typeof(Grid))]
	public class BlockMap : MonoBehaviour
	{
		#region facade
		
		public Vector3Int WorldToCell(Vector3 worldPosition)
		{
			return _gridLayout.WorldToCell(worldPosition);
		}

		public Block GetTopBlock(Vector3Int cellPosition)
		{
			foreach (var layer in _layers.Reverse())
			{
				var block = layer.GetBlock(cellPosition);
				if (block != null)
					return block;
			}

			return null;
		}

		#endregion

		#region interior

		private GridLayout _gridLayout;
		private BlockLayer[] _layers;

		private void Awake()
		{
			_gridLayout = GetComponent<GridLayout>();
			_layers = GetComponentsInChildren<BlockLayer>();
		}

		#endregion
	}
}