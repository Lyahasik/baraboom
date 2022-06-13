using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsReachable : ICondition
	{
		bool ICondition.Evaluate(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			var controls = context.BotProtocolResolver.Resolve<IBotController>();
			var pathFinder = context.BotProtocolResolver.Resolve<IBotPathFinder>();

			return pathFinder.FindPath(controls.Position, context.Player.Position) != null;
		}
	}
}