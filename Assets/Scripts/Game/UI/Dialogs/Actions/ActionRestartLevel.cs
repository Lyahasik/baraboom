using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionRestartLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_pauseState.Paused = false;
			_gameController.RestartLevel();
		}

		#endregion

		#region interior

		[Inject] private PauseState _pauseState;
		[Inject] private GameController _gameController;

		#endregion
	}
}