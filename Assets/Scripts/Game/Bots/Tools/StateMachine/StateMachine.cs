using UnityEngine;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public abstract class StateMachine : MonoBehaviour
	{
		private IState _current;

		protected abstract IState InitialState { get; }

		protected virtual void Start()
		{
			TrySwitchState(InitialState);
		}

		protected virtual void Update()
		{
			TryUpdateCurrentState();
			if (_current == null)
				return;

			foreach (var transition in _current.Transitions)
			{
				var next = TryEvaluateTransition(transition);
				if (next != null)
					TrySwitchState(next);
			}
		}

		private void TrySwitchState(IState next)
		{
			TryDeinitializeCurrentState();
			_current = next;
			TryInitializeCurrentState();
		}

		private void TryInitializeCurrentState()
		{
			try
			{
				_current.Initialize();
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't initialize state {0}: {1}", _current, exception);
				_current = null;
			}
		}

		private void TryDeinitializeCurrentState()
		{
			try
			{
				_current?.Deinitialize();
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't deinitialize state {0}: {1}", _current, exception);
			}
			finally
			{
				_current = null;
			}
		}

		private void TryUpdateCurrentState()
		{
			try
			{
				_current?.Update();
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't deinitialize state {0}: {1}", _current, exception);
				_current = null;
			}
		}

		private IState TryEvaluateTransition(ITransition transition)
		{
			try
			{
				return transition.Evaluate(_current);
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't evaluate transition {0}: {1}", transition, exception);
				return null;
			}
		}
	}
}