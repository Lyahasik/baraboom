using System;
using System.Collections.Generic;
using Baraboom.Game.Tools.Collections;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public class StateGraphData
	{
		#region facade

		public StateGraphData(Type initialState, IEnumerable<TransitionDescription> transitions)
		{
			_initialState = initialState;
			if (_initialState == null)
				throw new InvalidStateGraphException("Initial state is not set.");

			foreach (var transition in transitions)
			{
				if (!transition.Validate())
					throw new InvalidStateGraphException($"Transition ({transition}) is not valid.");

				_transitions.Add(transition.OriginState, (transition.DestinationState, transition.Condition));
			}
		}

		public Type InitialState => _initialState;

		public IEnumerable<(Type destinationState, TransitionCondition condition)> GetTransitions(Type originState)
		{
			return _transitions.Get(originState);
		}

		#endregion

		#region interior

		private readonly Type _initialState;
		private readonly MultiDictionary<Type, (Type destinationState, TransitionCondition condition)> _transitions = new();

		#endregion
	}
}