using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionUnpauseLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_pauseState.Paused = false;
			_pauseDialog.Hide();
		}

		#endregion

		#region interior

		[Inject] private PauseState _pauseState;
		[Inject] private Dialog _pauseDialog;

		#endregion
	}
}