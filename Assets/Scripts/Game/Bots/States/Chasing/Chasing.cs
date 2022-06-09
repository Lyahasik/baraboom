using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Bots.States
{
	[UsedImplicitly]
	public class Chasing : IState
	{
		#region facade

		void IState.Initialize(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			_pathFinder = context.PathFinder;
			_bot = context.Bot;
			_player = context.Player;

			_player.PositionChanged += OnPlayerPositionChanged;
		}

		void IState.Deinitialize()
		{
			_player.PositionChanged -= OnPlayerPositionChanged;
		}

		void IState.Update() {}

		#endregion

		#region interior
	
		private PathFinder _pathFinder;
		private IControllableBot _bot;
		private IObservablePlayer _player;

		private void ChasePlayer()
		{
			var path = _pathFinder.FindPath(_bot.Position, _player.Position);
			if (path == null)
				return;

			_bot.Move(path);
		}

		private void OnPlayerPositionChanged()
		{
			ChasePlayer();
		}

		#endregion
	}
}