using Baraboom.Core.UI;
using UnityEngine.SceneManagement;

namespace Baraboom.LevelMenu.UI
{
	public class StartLevelAction : ButtonAction
	{
		#region facade

		public string LevelScene
		{
			set => _levelScene = value;
		}

		#endregion

		#region extension

		protected override void OnClick()
		{
			SceneManager.LoadScene($"Scenes/{_levelScene}");
		}

		#endregion

		#region interior

		private string _levelScene;

		#endregion
	}
}