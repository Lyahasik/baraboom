using Baraboom.Game.Game;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionExit : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_gameController.ExitLevel();
		}

		#endregion

		#region interior

		[Inject] private GameController _gameController;

		#endregion
	}
}