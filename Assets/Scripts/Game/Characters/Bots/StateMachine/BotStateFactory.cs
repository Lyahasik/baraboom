using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.DI;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine
{
	[UsedImplicitly]
	public class BotStateFactory : FactoryDispatcher<BotState>, IStateFactory<BotState>
	{
		[Inject]
		private void Initialize(
			IFactory<BotStateNone> noneFactory,
			IFactory<BotStateRoaming> roamingFactory,
			IFactory<BotStateChasing> chasingFactory
		)
		{
			RegisterFactory<BotStateNone>(noneFactory);
			RegisterFactory<BotStateRoaming>(roamingFactory);
			RegisterFactory<BotStateChasing>(chasingFactory);
		}
	}
}