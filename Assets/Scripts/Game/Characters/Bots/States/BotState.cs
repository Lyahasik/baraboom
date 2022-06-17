using System;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.States
{
	public abstract class BotState : IState
	{
		#region facade

		void IState.Initialize(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			PathFinder = context.BotProtocolResolver.Resolve<IBotPathFinder>();
			Player = context.Player;

			_level = context.Level;
			_botController = context.BotProtocolResolver.Resolve<IBotController>();

			_level.Changed += OnLevelChanged;

			OnInitialized(context);
		}

		void IState.Deinitialize()
		{
			_level.Changed -= OnLevelChanged;

			OnDeinitialized();
		}

		void IState.Update()
		{
			OnUpdated();
		}

		#endregion

		#region extension

		protected IBotPathFinder PathFinder { get; private set; }

		protected IObservablePlayer Player { get; private set; }

		protected bool IsBotMoving => _botController.IsMoving;

		protected Vector3Int BotPosition => _botController.Position;

		protected void MoveBot(Path path)
		{
			_botController.Move(path);
		}

		protected void RequestBotStop(Action onStopped = null)
		{
			_botController.RequestStop(onStopped);
		}

		protected virtual void OnInitialized(BotStateMachineContext context) {}

		protected virtual void OnDeinitialized() {}

		protected virtual void OnUpdated() {}

		protected virtual void OnLevelChanged() {}

		#endregion

		#region interior

		private ILevel _level;
		private IBotController _botController;
		private IBotPathFinder _pathFinder;

		#endregion
	}
}