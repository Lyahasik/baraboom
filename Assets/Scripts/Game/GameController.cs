using UnityEngine;
using UnityEngine.SceneManagement;

namespace Baraboom.Game
{
	public class GameController : MonoBehaviour
	{
		#region facade

		public void RestartLevel()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void ExitLevel()
		{
			SceneManager.LoadScene("LevelMenu");
		}

		#endregion

		#region interior

		#endregion
	}
}