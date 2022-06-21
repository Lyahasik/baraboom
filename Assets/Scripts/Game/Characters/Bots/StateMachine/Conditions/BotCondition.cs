using Baraboom.Game.Characters.Bots.Tools.StateMachine;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	public abstract class BotCondition : ICondition
	{
		public abstract bool Evaluate();
	}
}