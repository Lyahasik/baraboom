using Baraboom.Game.Characters.Bots.Protocols;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsReachable : BotCondition
	{
		[Inject] private IObservablePlayer _player;
		[Inject] private IBotController _controller;
		[Inject] private IBotPathFinder _pathFinder;

		public override bool Evaluate()
		{
			if (_player.IsNull())
				return false;

			return _pathFinder.FindPath(_controller.Position, _player.Position) != null;
		}
	}
}