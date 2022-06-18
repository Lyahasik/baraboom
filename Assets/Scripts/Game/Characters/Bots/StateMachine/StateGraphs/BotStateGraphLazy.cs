using System;
using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.StateMachine.StateGraphs
{
	using IsPlayerReachable = BotConditionPlayerIsReachable;
	using IsPlayerVisible = BotConditionPlayerIsVisible;
	using Roaming = BotStateRoaming;
	using Chasing = BotStateChasing;

	[CreateAssetMenu(fileName = "BotStateGraphLazy", menuName = "Baraboom/Bot/State graphs/Lazy")]
	public class BotStateGraphLazy : StateGraph
	{
		public override Type InitialState => typeof(Roaming);

		public BotStateGraphLazy()
		{
			TransitIf<Roaming, Chasing, IsPlayerVisible>();
			TransitIfNot<Chasing, Roaming, IsPlayerVisible>();
		}
	}
}