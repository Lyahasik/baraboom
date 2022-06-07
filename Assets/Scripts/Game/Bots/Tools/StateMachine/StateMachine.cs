using UnityEngine;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public abstract class StateMachine : MonoBehaviour
	{
		private IState _current;

		protected abstract IState InitialState { get; } 

		protected virtual void Start()
		{
			SwitchState(InitialState);
		}

		protected virtual void Update()
		{
			if (_current == null)
				return;

			_current.Update();

			foreach (var transition in _current.Transitions)
			{
				var next = transition.Evaluate(_current);
				if (next != null)
				{
					SwitchState(next);
					break;
				}
			}
		}

		private void SwitchState(IState next)
		{
			_current?.Deinitialize();

			_current = next;
			_current.Initialize();
		}
	}
}