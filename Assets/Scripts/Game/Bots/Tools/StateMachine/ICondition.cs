namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public interface ICondition
	{
		public bool Evaluate(IContext context);
	}
}