using Baraboom.Game.Characters.Bots.Protocols;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.Conditions
{
	[UsedImplicitly]
	public class BotConditionPlayerIsReachable : BotCondition
	{
		[Inject] private IBotPlayerObserver _playerObserver;

		public override bool Evaluate()
		{
			return _playerObserver.IsPlayerReachable;
		}
	}
}