using System;
using System.Collections;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public sealed partial class StateMachine
	{
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
				_current?.Initialize();
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

		private IState InstantiateState(Type type)
		{
			try
			{
				return _stateFactory.Instantiate(type);
			}
			catch (Exception exception)
			{
				_logger.LogError("Couldn't instantiate state of type {0}: {1}", type, exception);
				return null;
			}
		}
	}
}