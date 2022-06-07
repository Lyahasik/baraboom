using System;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public class StateMachineException : Exception
	{
		public StateMachineException(string message = "") : base(message)
		{}
	}
}