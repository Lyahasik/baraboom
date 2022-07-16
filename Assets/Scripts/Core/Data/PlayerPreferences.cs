using UnityEngine;

namespace Baraboom.Core.Data
{
	public class PlayerPreferences : MonoBehaviour
	{
		#region facade

		public bool Music
		{
			get => PlayerPrefs.GetInt("music", 1) == 1;
			set => PlayerPrefs.SetInt("music", value ? 1 : 0);
		}

		public bool Sound
		{
			get => PlayerPrefs.GetInt("sound", 1) == 1;
			set => PlayerPrefs.SetInt("sound", value ? 1 : 0);
		}

		#endregion

		#region interior

		#endregion
	}
}