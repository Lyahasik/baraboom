using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using Zenject;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsVisible : BotCondition
	{
		[Inject] private DiscreteRayCaster _rayCaster;
		[Inject] private IObservablePlayer _player;
		[Inject] private IBotController _controller;

		public override bool Evaluate()
		{
			if (_player.IsNull())
				return false;

			var botPosition = _controller.Position;
			var playerPosition = _player.Position;

			if (botPosition == playerPosition)
				return true;

			var colliders = _rayCaster.CastRay2D(botPosition, playerPosition).ToArray();
			if (colliders.Length == 0)
			{
				Logger.For<BotConditionPlayerIsVisible>().LogWarning("Ray haven't collided with any entity!");
				return false;
			}

			return colliders.First().Transform.DiscretePosition == playerPosition;
		}
	}
}