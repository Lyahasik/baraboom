using System;
using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.StateGraphs
{
	using IsPlayerReachable = BotConditionPlayerIsReachable;
	using IsPlayerVisible = BotConditionPlayerIsVisible;
	using Roaming = BotStateRoaming;

	[UsedImplicitly]
	public class BotStateGraphSharpSighted : StateGraph
	{
		protected override Type InitialState => typeof(Roaming);

		public BotStateGraphSharpSighted()
		{
			Transit().From<Roaming>()
			         .To<BotStateChasingSharpSighted>()
			         .If(Evaluate<IsPlayerReachable>());

			Transit().From<BotStateChasingSharpSighted>()
			         .To<Roaming>()
			         .If(!Evaluate<IsPlayerReachable>());
		}
	}
}