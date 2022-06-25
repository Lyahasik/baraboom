namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface IState
	{
		void Initialize();

		void Deinitialize();

		void Update();
	}
}