using System;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	public abstract class BotState : IState
	{
		#region facade

		void IState.Initialize()
		{
			_level.Changed += OnLevelChanged;

			OnInitialized();
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

		[Inject]
		protected IBotPathFinder PathFinder { get; private set; }

		[Inject]
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

		protected virtual void OnInitialized() {}

		protected virtual void OnDeinitialized() {}

		protected virtual void OnUpdated() {}

		protected virtual void OnLevelChanged() {}

		#endregion

		#region interior

		[Inject] private ILevel _level;
		[Inject] private IBotController _botController;

		#endregion
	}
}