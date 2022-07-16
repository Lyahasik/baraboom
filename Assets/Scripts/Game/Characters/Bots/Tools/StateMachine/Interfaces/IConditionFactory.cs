using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface IConditionFactory
	{
		ICondition Instantiate(Type type);
	}

	public interface IConditionFactory<out T> : IConditionFactory where T : ICondition
	{
		ICondition IConditionFactory.Instantiate(Type type)
		{
			return this.Instantiate(type);
		}

		new T Instantiate(Type type);
	}
}