using Baraboom.Game.Bots.Tools.StateMachine;
using JetBrains.Annotations;

namespace Baraboom.Game.Bots.Conditions
{
	[UsedImplicitly]
	public class IsPlayerReachable : ICondition
	{
		bool ICondition.Evaluate(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			var path = context.PathFinder.FindPath(context.Bot.Position, context.Player.Position);
			return path != null;
		}
	}
}