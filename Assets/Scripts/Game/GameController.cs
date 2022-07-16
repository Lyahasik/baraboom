using Baraboom.Core.Tools;
using Baraboom.Core.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Baraboom.Game
{
	public class GameController : MonoBehaviour
	{
		#region facade

		public void RestartLevel()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					SceneManager.GetActiveScene().name,
					UIConstants.ClickSoundDuration
				)
			);
		}

		public void ExitLevel()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					"LevelMenu",
					UIConstants.ClickSoundDuration
				)
			);
		}

		#endregion

		#region interior

		#endregion
	}
}