using Baraboom.Level;
using UnityEngine;

namespace Baraboom
{
	public interface ILevel
	{
		public Vector3Int WorldToCell(Vector3 position);

		public Block GetTopBlock(Vector3Int cellPosition);
	}
}