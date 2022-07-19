using Baraboom.Core.Data;
using Baraboom.Core.Tools;
using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionGoToNextLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					$"Level{_persistentPlayerData.LevelsCompleted + 1}",
					UIConstants.ClickSoundDuration
				)
			);
		}

		#endregion

		#region interior

		[Inject] private PersistentPlayerData _persistentPlayerData;

		#endregion
	}
}