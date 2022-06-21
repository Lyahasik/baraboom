using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	[UsedImplicitly]
	public class BotStateChasing : BotState
	{
		#region facade

		protected override void OnInitialized()
		{
			Player.PositionChanged += OnPlayerPositionChanged;

			ChasePlayer();
		}

		protected override void OnDeinitialized()
		{
			if (Player.IsNotNull())
				Player.PositionChanged -= OnPlayerPositionChanged;
		}

		protected override void OnLevelChanged()
		{
			ChasePlayer();
		}

		#endregion

		#region interior

		private void ChasePlayer()
		{
			if (IsBotMoving)
			{
				RequestBotStop(ChasePlayer);
				return;
			}

			var path = PathFinder.FindPath(BotPosition, Player.Position);
			if (path == null)
				return;

			MoveBot(path);
		}

		private void OnPlayerPositionChanged()
		{
			ChasePlayer();
		}

		#endregion
	}
}