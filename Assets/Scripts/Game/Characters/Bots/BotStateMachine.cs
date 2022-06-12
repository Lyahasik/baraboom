using Baraboom.Game.Characters.Bots.Conditions;
using Baraboom.Game.Characters.Bots.States;
using Baraboom.Game.Characters.Bots.Tools.PathFinder;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots
{
	[RequireComponent(typeof(BotControlUnit))]
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
				var bot = GetComponent<BotControlUnit>();
				var player = GameObject.Find("Player").GetComponent<IObservablePlayer>(); // TODO Inject 

				return new BotStateMachineContext(level, pathFinder, bot, player);
			}
		}
	}
}