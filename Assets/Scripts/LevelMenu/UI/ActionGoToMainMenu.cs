using Baraboom.Core.Tools;
using Baraboom.Core.UI;

namespace Baraboom.MainMenu.UI
{
	public class ActionGoToMainMenu : ButtonAction
	{
		protected override void OnClick()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					"MainMenu",
					UIConstants.ClickSoundDuration
				)
			);
		}
	}
}