using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public abstract class StateMachine : MonoBehaviour
	{
		#region facade

		protected abstract IContext Context { get; }

		protected abstract StateGraph Graph { get;  }

		#endregion

		#region interior

		private IState _current;
		private IContext _context;
		private StateGraph _graph;
		private readonly Dictionary<Type, ICondition> _conditions = new();

		private IEnumerator Start()
		{
			_context = Context;
			_graph = Graph;

			yield return null; // TODO Remove this hack
			SwitchState(Graph.InitialState);
		}

		private void OnDestroy()
		{
			_context?.Dispose();
		}

		private void Update()
		{
			UpdateCurrentState();
			if (_current == null)
				return;

			foreach (var transition in _graph.GetTransitions(_current.GetType()))
			{
				if (EvaluateCondition(transition.Condition))
				{
					SwitchState(transition.TargetState);
					break;
				}
			}
		}

		private void SwitchState(Type stateType)
		{
			Debug.LogFormat("[{0}] Switching state from '{1}' to '{2}'", nameof(StateMachine), _current?.GetType(), stateType);
			
			DeinitializeCurrentState();

			if ((_current = InstantiateState(stateType)) != null)
				InitializeCurrentState();
		}

		private void InitializeCurrentState()
		{
			try
			{
				Debug.LogFormat("[{0}] Initializing state {1}", nameof(StateMachine), _current?.GetType());
				_current.Initialize(Context);
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't initialize state {0}: {1}", _current?.GetType(), exception);
				DeinitializeCurrentState();
			}
		}

		private void DeinitializeCurrentState()
		{
			try
			{
				Debug.LogFormat("[{0}] Deinitializing state {1}", nameof(StateMachine), _current?.GetType());
				_current?.Deinitialize();
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't deinitialize state {0}: {1}", _current?.GetType(), exception);
			}
			finally
			{
				_current = null;
			}
		}

		private void UpdateCurrentState()
		{
			try
			{
				_current?.Update();
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't deinitialize state {0}: {1}", _current?.GetType(), exception);
				DeinitializeCurrentState();
			}
		}

		private bool EvaluateCondition(Type conditionType)
		{
			try
			{
				return GetOrInstantiateCondition(conditionType)?.Evaluate(Context) ?? false;
			}
			catch (StateMachineException exception)
			{
				Debug.LogErrorFormat("Couldn't evaluate condition {0}: {1}", conditionType, exception);
				return false;
			}
		}

		private IState InstantiateState(Type type)
		{
			try
			{
				return (IState)Activator.CreateInstance(type);
			}
			catch (Exception exception)
			{
				Debug.LogErrorFormat("Couldn't instantiate state of type {0}: {1}", type, exception);
				return null;
			}
		}

		private ICondition GetOrInstantiateCondition(Type type)
		{
			if (_conditions.TryGetValue(type, out var result))
				return result;

			try
			{
				return _conditions[type] = (ICondition)Activator.CreateInstance(type);
			}
			catch (Exception exception)
			{
				Debug.LogErrorFormat("Can't instantiate condition of type {0}: {1}", type, exception);
				return null;
			}
		}

		#endregion
	}
}