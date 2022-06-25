using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.StateMachine;
using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Characters.Bots.Units;
using Zenject;

namespace Baraboom.Game.Characters.Bots
{
	public class BotInstaller : MonoInstaller
	{
		#region facade

		public override void InstallBindings()
		{
			InstallConditions();
			InstallStates();
			InstallFactories();
			InstallComponents();
		}

		#endregion

		#region interior

		private void InstallConditions()
		{
			Container.BindIFactory<BotConditionPlayerIsReachable>();
			Container.BindIFactory<BotConditionPlayerIsVisible>();
			Container.BindIFactory<BotConditionBotIsMoving>();
		}

		private void InstallStates()
		{
			Container.BindIFactory<BotStateNone>();
			Container.BindIFactory<BotStateRoaming>();
			Container.BindIFactory<BotStateChasingShortSighted>();
			Container.BindIFactory<BotStateChasingSharpSighted>();
		}

		private void InstallFactories()
		{
			Container.Bind<IConditionFactory>().To<BotConditionFactory>().AsSingle();
			Container.Bind<IStateFactory>().To<BotStateFactory>().AsSingle();
		}

		private void InstallComponents()
		{
			Container.Bind(typeof(IBotController), typeof(IBotRoamingData))
			         .FromInstance(GetComponent<BotControlUnit>());

			Container.Bind(typeof(IBotPathFinder), typeof(IBotPathValidator))
			         .FromInstance(GetComponent<BotNavigationUnit>());

			Container.Bind(typeof(IBotChasingData), typeof(IBotPlayerObserver))
			         .FromInstance(GetComponent<BotAttackUnit>());
		}

		#endregion
	}
}