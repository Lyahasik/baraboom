using System;
using Baraboom.Game.Bots.Tools;
using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using UnityEngine;

namespace Baraboom.Game.Bots.States
{
	public abstract class Base : IState
	{
		#region facade

		void IState.Initialize(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			PathFinder = context.PathFinder;
			Player = context.Player;

			_level = context.Level;
			_bot = context.Bot;

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
		
		protected PathFinder PathFinder { get; private set; }

		protected IObservablePlayer Player { get; private set; }

		protected bool IsBotMoving => _bot.IsMoving;

		protected Vector2Int BotPosition => _bot.Position;

		protected void MoveBot(Path path)
		{
			_bot.Move(path);
		}

		protected void RequestBotStop(Action onStopped = null)
		{
			_bot.RequestStop(onStopped);
		}

		protected virtual void OnInitialized(BotStateMachineContext context) {}

		protected virtual void OnDeinitialized() {}

		protected virtual void OnUpdated() {}

		protected virtual void OnLevelChanged() {}

		#endregion
		
		#region interior

		private ILevel _level;
		private IControllableBot _bot;

		#endregion
	}
}