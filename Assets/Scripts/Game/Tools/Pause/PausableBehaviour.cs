using Baraboom.Core.Tools;
using Zenject;

namespace Baraboom.Game
{
	public class PausableBehaviour : VerboseBehaviour
	{
		#region extenion

		protected virtual void Update()
		{
			if (!_pauseState.Paused)
				UpdateIfNotPaused();
		}

		protected virtual void UpdateIfNotPaused() {}

		#endregion

		#region interior

		[Inject] private PauseState _pauseState;

		#endregion
	}
}