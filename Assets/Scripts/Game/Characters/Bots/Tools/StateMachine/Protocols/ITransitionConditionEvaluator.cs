using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface ITransitionConditionEvaluator
	{
		public bool Evaluate(Type conditionType);
	}
}