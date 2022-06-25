using System;
using System.Collections.Generic;
using Baraboom.Game.Tools.Collections;

namespace Baraboom.Game.Characters.Bots.Tools.StateMachine
{
	public abstract class StateGraph
	{
		#region facade

		public StateGraphData ExportData()
		{
			return new StateGraphData(InitialState, _transitions);
		}

		#endregion

		#region extension

		protected abstract Type InitialState { get; }

		protected TransitionDescriptionBuilder Transit()
		{
			var builder = new TransitionDescriptionBuilder();
			_transitions.Add(builder.Description);

			return builder;
		}

		protected TransitionCondition Evaluate<T>() where T : ICondition
		{
			return TransitionCondition.ForType<T>();
		}

		#endregion

		#region interior

		private readonly List<TransitionDescription> _transitions = new();

		#endregion
	}
}