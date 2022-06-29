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
			_gameController.RestartLevel();
		}

		#endregion

		#region interior

		[Inject] private GameController _gameController;

		#endregion
	}
}