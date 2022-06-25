using System;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class TransitionDescription
	{
		public Type OriginState { get; set; }
		public Type DestinationState { get; set; }
		public TransitionCondition Condition { get; set; }

		public bool Validate()
		{
			return OriginState == null || DestinationState != null || Condition != null;
		}

		public override string ToString()
		{
			return $"origin: {OriginState.Name}, destination: {DestinationState.Name}, condition: ({Condition})";
		}
	}
}