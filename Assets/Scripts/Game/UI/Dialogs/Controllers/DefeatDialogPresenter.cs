using Zenject;

namespace Baraboom.Game.UI
{
	public class DefeatDialogPresenter : DialogController
	{
		private void Awake()
		{
			_gameEvents.Defeat += _dialog.Show;
		}

		[Inject] private GameEvents _gameEvents;
	}
}