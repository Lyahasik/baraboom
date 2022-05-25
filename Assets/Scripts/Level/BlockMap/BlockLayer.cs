using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Baraboom.Level
{
	[RequireComponent(typeof(Tilemap))]
	public class BlockLayer : MonoBehaviour
	{
		#region facade

		[CanBeNull]
		public Block GetBlock(Vector3Int cellPosition)
		{
			return _blocks.TryGetValue(cellPosition, out var result) ? result : null;
		}

		#endregion

		#region interior

		private Tilemap _tilemap;
		private readonly Dictionary<Vector3Int, Block> _blocks = new();

		private void Awake()
		{
			_tilemap = GetComponent<Tilemap>();
			for (var i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				var cellPosition = _tilemap.WorldToCell(child.transform.position);

				_blocks[cellPosition] = child.GetComponent<Block>();
			}
		}

		#endregion
	}
}