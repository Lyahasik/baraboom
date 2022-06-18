using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsVisible : ICondition
	{
		bool ICondition.Evaluate(Context abstractContext)
		{
			var rayCaster = GameObject.Find("DiscreteRayCaster").GetComponent<DiscreteRayCaster>(); // TODO Inject

			var context = (BotStateMachineContext)abstractContext;
			if (context.Player.IsNull())
				return false;

			var botPosition = context.BotProtocolResolver.Resolve<IBotController>().Position;
			var playerPosition = context.Player.Position;

			if (botPosition == playerPosition)
				return true;

			var colliders = rayCaster.CastRay2D(botPosition, playerPosition).ToArray();
			if (colliders.Length == 0)
			{
				Logger.For<BotConditionPlayerIsVisible>().LogWarning("Ray haven't collided with any entity!");
				return false;
			}

			return colliders.First().Transform.DiscretePosition == playerPosition;
		}
	}
}