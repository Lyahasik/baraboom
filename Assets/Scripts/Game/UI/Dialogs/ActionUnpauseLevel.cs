using Baraboom.Core.UI;
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
			_pauseDialog.Hide();
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;
		[Inject] private Dialog _pauseDialog;

		#endregion
	}
}