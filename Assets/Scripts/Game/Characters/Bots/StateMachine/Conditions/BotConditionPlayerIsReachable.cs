using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsReachable : ICondition
	{
		bool ICondition.Evaluate(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;
			if (context.Player.IsNull())
				return false;

			var controller = context.BotProtocolResolver.Resolve<IBotController>();
			var pathFinder = context.BotProtocolResolver.Resolve<IBotPathFinder>();

			return pathFinder.FindPath(controller.Position, context.Player.Position) != null;
		}
	}
}