using Baraboom.Game.Characters.Bots.Protocols;
using JetBrains.Annotations;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsReachable : BotCondition
	{
		protected override bool Evaluate(BotStateMachineContext context)
		{
			if (context.Player.IsNull())
				return false;

			var controller = context.BotProtocolResolver.Resolve<IBotController>();
			var pathFinder = context.BotProtocolResolver.Resolve<IBotPathFinder>();

			return pathFinder.FindPath(controller.Position, context.Player.Position) != null;
		}
	}
}