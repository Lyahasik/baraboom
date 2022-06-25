using System;
using System.Collections;
using System.Collections.Generic;
using TypeReferences;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public sealed partial class StateMachine
	{
		private bool EvaluateCondition(TransitionCondition condition)
		{
			try
			{
				return condition.Evaluate(this);
			}
			catch (StateMachineException exception)
			{
				_logger.LogError("Couldn't evaluate condition ({0}): {1}", condition, exception);
				return false;
			}
		}

		bool ITransitionConditionEvaluator.Evaluate(Type type)
		{
			if (!_conditions.TryGetValue(type, out var instance))
			{
				try
				{
					instance = _conditions[type] = _conditionFactory.Instantiate(type);
				}
				catch (Exception exception)
				{
					_logger.LogError("Can't instantiate condition of type {0}: {1}", type, exception);
					return false;
				}
			}

			return instance.Evaluate();
		}
	}
}