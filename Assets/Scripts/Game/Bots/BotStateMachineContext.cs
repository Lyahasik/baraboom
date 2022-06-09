using Baraboom.Game.Bots.States;
using Baraboom.Game.Bots.Tools.PathFinder;
using StateMachine = Baraboom.Game.Bots.Tools.StateMachine;

namespace Baraboom.Game.Bots
{
	public class BotStateMachineContext : StateMachine.IContext
	{
		public PathFinder PathFinder { get; }

		public IControllableBot Bot { get; }

		public IObservablePlayer Player { get; }

		public BotStateMachineContext(PathFinder pathFinder, IControllableBot bot, IObservablePlayer player)
		{
			PathFinder = pathFinder;
			Bot = bot;
			Player = player;
		}

		void StateMachine.IContext.Dispose()
		{
			PathFinder?.Dispose();
		}
	}
}