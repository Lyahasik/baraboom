using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Protocols;
using StateMachine = Baraboom.Game.Characters.Bots.Tools.StateMachine;

namespace Baraboom.Game.Characters.Bots
{
	public class BotStateMachineContext : StateMachine.IContext
	{
		public ILevel Level { get; }

		public IObservablePlayer Player { get; }

		public IProtocolResolver BotProtocolResolver { get; }

		public BotStateMachineContext(ILevel level, IObservablePlayer player, IProtocolResolver botProtocolResolver)
		{
			Level = level;
			Player = player;
			BotProtocolResolver = botProtocolResolver;
		}
	}
}