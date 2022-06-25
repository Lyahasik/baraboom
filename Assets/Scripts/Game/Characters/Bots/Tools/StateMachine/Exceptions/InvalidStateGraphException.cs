using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class InvalidStateGraphException : Exception
	{
		public InvalidStateGraphException(string message = "") : base(message)
		{}
	}
}