using Zenject;

namespace Baraboom.Game.UI
{
	public class VictoryDialogPresenter : DialogController
	{
		private void Awake()
		{
			_gameEvents.Victory += _dialog.Show;
		}

		[Inject] private GameEvents _gameEvents;
	}
}