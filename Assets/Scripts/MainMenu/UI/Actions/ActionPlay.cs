using Baraboom.Core.UI;
using UnityEngine.SceneManagement;

namespace Baraboom.MainMenu.UI
{
	public class ActionPlay : ButtonAction
	{
		protected override void OnClick()
		{
			SceneManager.LoadScene("Scenes/LevelMenu");
		}
	}
}