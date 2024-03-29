using Baraboom.Core.Tools;
using Baraboom.Core.UI;

namespace Baraboom.MainMenu.UI
{
	public class ActionPlay : ButtonAction
	{
		protected override void OnClick()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					"LevelMenu",
					UIConstants.ClickSoundDuration
				)
			);
		}
	}
}