using Baraboom.Game.Bots.Conditions;
using Baraboom.Game.Bots.States;
using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	[RequireComponent(typeof(BotController))]
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
				var pathFinder = new PathFinder(level);

				var bot = GetComponent<BotController>();
				var player = GameObject.Find("Player").GetComponent<IObservablePlayer>(); // TODO Inject 

				return new BotStateMachineContext(pathFinder, bot, player);
			}
		}
	}
}