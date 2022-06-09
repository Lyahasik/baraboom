namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public interface IState
	{
		void Initialize(IContext context);

		void Deinitialize();

		void Update();
	}
}