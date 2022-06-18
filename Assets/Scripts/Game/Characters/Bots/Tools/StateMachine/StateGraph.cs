using System;
using System.Collections.Generic;
using Baraboom.Game.Tools.Collections;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public abstract class StateGraph : ScriptableObject
	{
		#region facade

		public record TransitionDescription
		{
			public Type TargetState { get; set; }
			public Type Condition { get; set; }
			public bool Negate { get; set; }
		}

		public IEnumerable<TransitionDescription> GetTransitions(Type stateType)
		{
			return _transitions.Get(stateType);
		}

		#endregion

		#region extension

		public abstract Type InitialState { get; }

		protected void TransitIf<TSource, TTarget, TCondition>()
			where TSource : IState
			where TTarget : IState
			where TCondition : ICondition
		{
			Transit<TSource, TTarget, TCondition>(false);
		}

		protected void TransitIfNot<TSource, TTarget, TCondition>()
			where TSource : IState
			where TTarget : IState
			where TCondition : ICondition
		{
			Transit<TSource, TTarget, TCondition>(true);
		}

		#endregion

		#region interior

		private readonly MultiDictionary<Type, TransitionDescription> _transitions = new();

		private void Transit<TSource, TTarget, TCondition>(bool negate)
			where TSource : IState
			where TTarget : IState
			where TCondition : ICondition
		{
			var transitionDescription = new TransitionDescription
			{
				TargetState = typeof(TTarget),
				Condition = typeof(TCondition),
				Negate = negate
			};

			_transitions.Add(typeof(TSource), transitionDescription);
		}

		#endregion
	}
}