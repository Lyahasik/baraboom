using UnityEngine;

namespace Baraboom.Core.Data
{
	[CreateAssetMenu(fileName = "GameData", menuName = "Baraboom/GameData")]
	public class GameData : ScriptableObject
	{
		#region facade

		public int LevelCount
		{
			get => _levelCount;
		}

		#endregion

		#region interior

		[SerializeField] private int _levelCount;

		#endregion
	}
}