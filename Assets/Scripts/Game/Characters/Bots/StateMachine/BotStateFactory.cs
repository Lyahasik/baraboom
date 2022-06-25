using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.DI;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine
{
	[UsedImplicitly]
	public class BotStateFactory : FactoryDispatcher<BotStateBase>, IStateFactory<BotStateBase>
	{
		[Inject]
		private void Initialize(
			IFactory<BotStateNone> none,
			IFactory<BotStateRoaming> roaming,
			IFactory<BotStateChasingShortSighted> chasingShortSighted,
			IFactory<BotStateChasingSharpSighted> chasingSharpSighted
		)
		{
			RegisterFactory(none);
			RegisterFactory(roaming);
			RegisterFactory(chasingShortSighted);
			RegisterFactory(chasingSharpSighted);
		}
	}
}