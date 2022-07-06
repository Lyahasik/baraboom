using Baraboom.Core.UI;
using Baraboom.Game.Game;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionExit : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_gameState.Paused = false;
			_gameController.ExitLevel();
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;
		[Inject] private GameController _gameController;

		#endregion
	}
}