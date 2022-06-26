using Baraboom.Game.Tools;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionSwitchPause : ButtonAction
	{
		#region facade

		protected override void OnClick()
		{
			_gameState.Paused = !_gameState.Paused;
		}

		#endregion

		#region interior

		[Inject] private GameState _gameState;

		#endregion
	}
}