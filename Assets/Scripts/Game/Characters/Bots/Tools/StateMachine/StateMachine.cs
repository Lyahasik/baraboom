using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	[RequireComponent(typeof(IContext))]
	[RequireComponent(typeof(StateGraph))]
	public sealed class StateMachine : MonoBehaviour
	{
		private Logger _logger;
		private IContext _context;
		private StateGraph _graph;
		private IState _current;
		private readonly Dictionary<Type, ICondition> _conditions = new();

		private void Awake()
		{
			_logger = Logger.For<StateMachine>();

			_context = GetComponent<IContext>();
			_graph = GetComponent<StateGraph>();
		}

		private IEnumerator Start()
		{
			yield return null; // Wait one frame for all block to register self. TODO Remove the hack.
			SwitchState(_graph.InitialState);
		}

		private void OnDestroy()
		{
			_current?.Deinitialize();
			_current = null;

			_context = null;
		}

		private void Update()
		{
			UpdateCurrentState();
			if (_current == null)
				return;

			foreach (var transition in _graph.GetTransitions(_current.GetType()))
			{
				if (EvaluateCondition(transition))
				{
					SwitchState(transition.TargetState);
					break;
				}
			}
		}

		private void SwitchState(Type stateType)
		{
			_logger.Log("Switching state from '{0}' to '{1}'", _current?.GetType(), stateType);

			DeinitializeCurrentState();

			if ((_current = InstantiateState(stateType)) != null)
				InitializeCurrentState();
		}

		private void InitializeCurrentState()
		{
			try
			{
				_logger.Log("Initializing state {0}", _current?.GetType());
				_current?.Initialize(_context);
			}
			catch (StateMachineException exception)
			{
				_logger.LogError("Couldn't initialize state {0}: {1}", _current?.GetType(), exception);
				DeinitializeCurrentState();
			}
		}

		private void DeinitializeCurrentState()
		{
			try
			{
				_logger.Log("Deinitializing state {0}", _current?.GetType());
				_current?.Deinitialize();
			}
			catch (StateMachineException exception)
			{
				_logger.LogError("Couldn't deinitialize state {0}: {1}", _current?.GetType(), exception);
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
				_logger.LogError("Couldn't deinitialize state {0}: {1}", _current?.GetType(), exception);
				DeinitializeCurrentState();
			}
		}

		private bool EvaluateCondition(StateGraph.TransitionDescription transition)
		{
			try
			{
				var condition = GetOrInstantiateCondition(transition.Condition);
				if (condition == null)
					return false;

				return condition.Evaluate(_context) ^ transition.Negate;
			}
			catch (StateMachineException exception)
			{
				_logger.LogError("Couldn't evaluate condition {0}: {1}", transition.Condition, exception);
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
				_logger.LogError("Couldn't instantiate state of type {0}: {1}", type, exception);
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
				_logger.LogError("Can't instantiate condition of type {0}: {1}", type, exception);
				return null;
			}
		}
	}
}