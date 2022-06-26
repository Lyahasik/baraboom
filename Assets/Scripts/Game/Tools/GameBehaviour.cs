using Zenject;

namespace Baraboom.Game.Tools
{
	public class GameBehaviour : VerboseBehaviour
	{
		#region extenion

		protected virtual void Update()
		{
			if (!_gameState.Paused)
				UpdateIfNotPaused();
		}

		protected virtual void UpdateIfNotPaused() {}

		#endregion

		#region interior

		[Inject] private GameState _gameState;

		#endregion
	}
}