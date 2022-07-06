using UnityEngine;

namespace Baraboom.Game.Data
{
	public class LevelData : MonoBehaviour
	{
		#region facade

		public int Index => _index;

		#endregion

		#region interior

		[SerializeField] private int _index;

		#endregion
	}
}