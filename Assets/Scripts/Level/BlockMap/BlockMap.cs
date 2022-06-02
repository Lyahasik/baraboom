using System.Linq;
using UnityEngine;

namespace Baraboom.Level
{
	[RequireComponent(typeof(Grid))]
	public class BlockMap : MonoBehaviour
	{
		#region facade
		
		public Block GetTopBlock(Vector2Int cellPosition)
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

		private BlockLayer[] _layers;

		private void Awake()
		{
			_layers = GetComponentsInChildren<BlockLayer>();
		}

		#endregion
	}
}