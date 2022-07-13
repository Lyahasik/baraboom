using Baraboom.Core.UI;
using UnityEngine.SceneManagement;

namespace Baraboom.MainMenu.UI
{
	public class ActionMainMenu : ButtonAction
	{
		protected override void OnClick()
		{
			SceneManager.LoadScene("Scenes/MainMenu");
		}
	}
}