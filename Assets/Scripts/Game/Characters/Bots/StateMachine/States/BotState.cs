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
			if (!IsBotMoving)
				_currentPath = null;

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
			_currentPath = path;
			_botController.Move(path);
		}

		protected void RequestBotStop()
		{
			_botController.RequestStop();
		}

		protected virtual void OnInitialized() {}

		protected virtual void OnDeinitialized() {}

		protected virtual void OnUpdated() {}

		#endregion

		#region interior

		[Inject] private ILevel _level;
		[Inject] private IBotController _botController;
		[Inject] private IBotPathValidator _pathValidator;

		private Path _currentPath;

		private void OnLevelChanged()
		{
			if (_currentPath == null)
				return;

			if (!_pathValidator.IsValid(_currentPath))
				RequestBotStop();
		}

		#endregion
	}
}