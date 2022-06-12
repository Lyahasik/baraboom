namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface IState
	{
		void Initialize(IContext context);

		void Deinitialize();

		void Update();
	}
}