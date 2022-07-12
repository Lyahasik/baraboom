using Baraboom.Core.UI;
using Baraboom.Game.Game;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionRestartLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_gameState.Paused = false;
			_gameController.RestartLevel();
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;
		[Inject] private GameController _gameController;

		#endregion
	}
}