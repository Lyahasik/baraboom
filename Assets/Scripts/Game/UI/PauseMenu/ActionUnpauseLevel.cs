using Baraboom.Game.Game;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionUnpauseLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_gameState.Paused = false;
			_pauseMenu.Hide();
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;
		[Inject] private PauseMenu _pauseMenu;

		#endregion
	}
}