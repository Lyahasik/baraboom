using System;
using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.StateGraphs
{
	using IsPlayerVisible = BotConditionPlayerIsVisible;
	using IsBotMoving = BotConditionBotIsMoving;
	using Roaming = BotStateRoaming;
	using ChasingShortSighted = BotStateChasingShortSighted;

	[UsedImplicitly]
	public class BotStateGraphShortSighted : StateGraph
	{
		protected override Type InitialState => typeof(Roaming);

		public BotStateGraphShortSighted()
		{
			Transit().From<Roaming>()
			         .To<ChasingShortSighted>()
			         .If(Evaluate<IsPlayerVisible>());

			Transit().From<ChasingShortSighted>()
			         .To<Roaming>()
			         .If(!Evaluate<IsPlayerVisible>() & !Evaluate<IsBotMoving>());
		}
	}
}