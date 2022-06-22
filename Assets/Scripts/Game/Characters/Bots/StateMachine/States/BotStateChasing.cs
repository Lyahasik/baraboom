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

			if (IsBotMoving)
				RequestBotStop();
			else
				ChasePlayer();
		}

		protected override void OnDeinitialized()
		{
			if (Player.IsNotNull())
				Player.PositionChanged -= OnPlayerPositionChanged;
		}

		protected override void OnUpdated()
		{
			if (!IsBotMoving)
				ChasePlayer();
		}

		#endregion

		#region interior

		private void ChasePlayer()
		{
			if (Player.IsNull())
				return;

			var path = PathFinder.FindPath(BotPosition, Player.Position);
			if (path == null)
				return;

			MoveBot(path);
		}

		private void OnPlayerPositionChanged()
		{
			RequestBotStop();
		}

		#endregion
	}
}