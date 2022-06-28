using Baraboom.Game.Game;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionPause : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_gameState.Paused = true;
			_pauseMenu.Show();
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;
		[Inject] private PauseMenu _pauseMenu;

		#endregion
	}
}