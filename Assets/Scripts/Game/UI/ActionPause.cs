using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionPause : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_pauseState.Paused = true;
			_dialog.Show();
		}

		#endregion

		#region interior

		[Inject] private PauseState _pauseState;
		[Inject(Id = "pause")] private Dialog _dialog;

		#endregion
	}
}