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

	[CreateAssetMenu(fileName = "BotStateGraphSmart", menuName = "Baraboom/Bot/State graphs/Smart")]
	public class BotStateGraphSmart : StateGraph
	{
		public override Type InitialState => typeof(Roaming);

		public BotStateGraphSmart()
		{
			TransitIf<Roaming, Chasing, IsPlayerReachable>();
			TransitIfNot<Chasing, Roaming, IsPlayerReachable>();
		}
	}
}