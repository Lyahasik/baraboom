using System;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.StateGraphs
{
	using Roaming = BotStateRoaming;

	[UsedImplicitly]
	public class BotStateGraphBlind : StateGraph
	{
		protected override Type InitialState => typeof(Roaming);
	}
}