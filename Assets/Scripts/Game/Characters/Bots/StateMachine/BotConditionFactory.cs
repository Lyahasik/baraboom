using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.DI;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine
{
	[UsedImplicitly]
	public class BotConditionFactory : FactoryDispatcher<BotCondition>, IConditionFactory<BotCondition>
	{
		[Inject]
		private void Initialize(
			IFactory<BotConditionPlayerIsReachable> isPlayerReachable,
			IFactory<BotConditionPlayerIsVisible> isPlayerVisible,
			IFactory<BotConditionBotIsMoving> isBotMoving
		)
		{
			RegisterFactory(isPlayerReachable);
			RegisterFactory(isPlayerVisible);
			RegisterFactory(isBotMoving);
		}
	}
}