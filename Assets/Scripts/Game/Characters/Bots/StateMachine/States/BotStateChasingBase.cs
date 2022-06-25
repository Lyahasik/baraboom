using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	public abstract class BotStateChasingBase : BotStateBase
	{
		#region facade

		protected override void OnInitialized()
		{
			if (_chasingData is null)
				throw new StateMachineException("Bot doesn't support chasing behaviour.");

			Player.PositionChanged += OnPlayerPositionChanged;

			InitializePointer();
			FetchPointer();
			ProcessPointer();
		}

		protected override void OnDeinitialized()
		{
			if (Player.IsNotNull())
				Player.PositionChanged -= OnPlayerPositionChanged;
		}

		protected override void OnUpdated()
		{
			if (!CanMakeDecision)
				return;

			ProcessPointer();
		}

		#endregion

		#region extension

		protected abstract bool ShouldChasePlayer { get; }

		#endregion

		#region interior

		[InjectOptional] private IBotChasingData _chasingData;

		private readonly Logger _logger = Logger.For<BotStateChasingShortSighted>();

		private ManualTimer _decisionPauseTimer;
		private Vector3Int _pointer;

		private bool CanMakeDecision
		{
			get => _decisionPauseTimer is not { IsRunning: true };
		}

		private void InitializePointer()
		{
			_pointer = BotPosition;
		}

		private void FetchPointer()
		{
			if (ShouldChasePlayer)
			{
				_pointer = Player.Position;
				_logger.Log("Set pointer to {0}", _pointer);
			}
		}

		private void ProcessPointer()
		{
			if (BotPosition == _pointer)
				return;

			if (IsBotMoving)
				return;

			var path = PathFinder.FindPath(BotPosition, _pointer);
			if (path == null)
				return;

			SetBotPath(path);

			_decisionPauseTimer = new ManualTimer(_chasingData.DecisionPause);
		}

		private void OnPlayerPositionChanged()
		{
			if (!CanMakeDecision)
				return;

			RequestBotStop();
			FetchPointer();
		}

		#endregion
	}
}