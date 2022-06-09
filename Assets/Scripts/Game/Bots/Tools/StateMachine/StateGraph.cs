using System;
using System.Collections.Generic;
using System.Linq;

namespace Baraboom.Game.Bots.Tools.StateMachine
{
	public class StateGraph
	{
		#region facade

		public record TransitionDescription
		{
			public Type TargetState { get; set; }
			public Type Condition { get; set; }
		}

		public static StateGraph WithInitialState<T>() where T : IState
		{
			return new StateGraph(typeof(T));
		}

		public StateGraph WithTransition<TSource, TTarget, TCondition>()
			where TSource : IState
			where TTarget : IState
			where TCondition : ICondition
		{
			var sourceState = typeof(TSource);
			var targetState = typeof(TTarget);
			var condition = typeof(TCondition);

			if (!_transitions.TryGetValue(sourceState, out var transitions))
				transitions = _transitions[sourceState] = new List<TransitionDescription>();

			transitions.Add(new TransitionDescription { TargetState = targetState, Condition = condition });

			return this;
		}

		public Type InitialState => _initialState;

		public IEnumerable<TransitionDescription> GetTransitions(Type stateType)
		{
			if (_transitions.TryGetValue(stateType, out var transitions))
				return transitions;

			return Enumerable.Empty<TransitionDescription>();
		}

		#endregion

		#region interior

		private readonly Type _initialState;
		private readonly Dictionary<Type, List<TransitionDescription>> _transitions = new();

		private StateGraph(Type initialState)
		{
			_initialState = initialState;
		}

		#endregion
	}
}