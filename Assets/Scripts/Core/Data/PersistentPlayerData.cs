using UnityEngine;

namespace Baraboom.Core.Data
{
	public class PersistentPlayerData : MonoBehaviour
	{
		#region facade

		public int LevelsCompleted
		{
			get => PlayerPrefs.GetInt(KeyLevelsCompleted, 0);
			set => PlayerPrefs.SetInt(KeyLevelsCompleted, value);
		}

		#endregion

		#region interior

		private const string KeyLevelsCompleted = "levels_completed";

		#endregion
	}
}