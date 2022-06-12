using Baraboom.Game.Bots.States;
using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Level;
using StateMachine = Baraboom.Game.Bots.Tools.StateMachine;

namespace Baraboom.Game.Bots
{
	public class BotStateMachineContext : StateMachine.IContext
	{
		public ILevel Level { get; }

		public PathFinder PathFinder { get; }

		public IControllableBot Bot { get; }

		public IObservablePlayer Player { get; }

		public BotStateMachineContext(ILevel level, PathFinder pathFinder, IControllableBot bot, IObservablePlayer player)
		{
			Level = level;
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