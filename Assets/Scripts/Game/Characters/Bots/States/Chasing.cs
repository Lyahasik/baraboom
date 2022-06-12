using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.States
{
	[UsedImplicitly]
	public class Chasing : Base
	{
		#region facade

		protected override void OnInitialized(BotStateMachineContext _)
		{
			Player.PositionChanged += OnPlayerPositionChanged;

			ChasePlayer();
		}

		protected override void OnDeinitialized()
		{
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