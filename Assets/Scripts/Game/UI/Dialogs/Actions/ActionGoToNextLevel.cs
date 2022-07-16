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
					$"Level {_playerData.LevelsCompleted}",
					UIConstants.ClickSoundDuration
				)
			);
		}

		#endregion

		#region interior

		[Inject] private PlayerData _playerData;

		#endregion
	}
}