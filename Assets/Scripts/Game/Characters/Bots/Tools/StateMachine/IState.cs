namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public interface IState
	{
		void Initialize(Context context);

		void Deinitialize();

		void Update();
	}
}