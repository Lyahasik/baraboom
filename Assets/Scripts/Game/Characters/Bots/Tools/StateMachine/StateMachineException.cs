using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class StateMachineException : Exception
	{
		public StateMachineException(string message = "") : base(message)
		{}
	}
}