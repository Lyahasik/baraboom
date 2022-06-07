namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public interface ITransition
	{
		public IState Evaluate(IState current);
	}
}