using Baraboom.Game.Characters.Bots.Tools.StateMachine;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	public abstract class BotCondition : ICondition
	{
		bool ICondition.Evaluate(IContext context)
		{
			return Evaluate((BotStateMachineContext)context);
		}

		protected abstract bool Evaluate(BotStateMachineContext context);
	}
}