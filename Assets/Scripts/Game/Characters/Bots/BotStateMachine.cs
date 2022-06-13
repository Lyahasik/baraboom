using Baraboom.Game.Characters.Bots.Conditions;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Characters.Bots.Units;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Protocols;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots
{
	using IsPlayerReachable = BotConditionPlayerIsReachable;
	using Roaming = BotStateRoaming;
	using Chasing = BotStateChasing;

	[RequireComponent(typeof(BotAttackUnit))]
	[RequireComponent(typeof(BotControlUnit))]
	[RequireComponent(typeof(BotNavigationUnit))]
	public sealed class BotStateMachine : StateMachine
	{
		protected override StateGraph Graph
		{
			get
			{
				return StateGraph.WithInitialState<Roaming>()
				                 .WithTransition<Roaming, Chasing, IsPlayerReachable>();
			}
		}

		protected override IContext Context
		{
			get
			{
				var level = GameObject.Find("Level").GetComponent<ILevel>(); // TODO Inject
				var player = GameObject.Find("Player").GetComponent<IObservablePlayer>(); // TODO Inject
				var botStateResolver = new GameObjectProtocolResolver(gameObject);

				return new BotStateMachineContext(level, player, botStateResolver);
			}
		}
	}
}