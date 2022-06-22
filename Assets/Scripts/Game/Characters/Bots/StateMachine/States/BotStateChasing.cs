using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	[UsedImplicitly]
	public class BotStateChasing : BotState
	{
		#region facade

		protected override void OnInitialized()
		{
			if (_chasingData is null)
				throw new StateMachineException("Bot doesn't support chasing behaviour.");

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
			if (_decisionPauseTimer is { IsRunning: true })
				return;
			_decisionPauseTimer = null;

			if (Player.IsNull())
				return;

			if (!IsBotMoving && Player.Position != _pointer)
				ChasePlayer();
		}

		#endregion

		#region interior

		[InjectOptional] private IBotChasingData _chasingData;

		private ManualTimer _decisionPauseTimer;
		private Vector3Int _pointer;

		private void ChasePlayer()
		{
			if (Player.IsNull())
				return;

			var path = PathFinder.FindPath(BotPosition, Player.Position);
			if (path == null)
				return;

			_pointer = Player.Position;

			MoveBot(path);
			_decisionPauseTimer = new ManualTimer(_chasingData.DecisionPause);
		}

		private void OnPlayerPositionChanged()
		{
			if (_decisionPauseTimer is { IsRunning: true })
				return;

			RequestBotStop();
		}

		#endregion
	}
}