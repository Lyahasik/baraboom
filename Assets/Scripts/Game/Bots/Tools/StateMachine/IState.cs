using System.Collections.Generic;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public interface IState
	{
		IEnumerable<ITransition> Transitions { get; }

		void Initialize();

		void Deinitialize();

		void Update();
	}
}