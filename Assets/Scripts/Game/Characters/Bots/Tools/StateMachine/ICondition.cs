namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface ICondition
	{
		public bool Evaluate(IContext context);
	}
}