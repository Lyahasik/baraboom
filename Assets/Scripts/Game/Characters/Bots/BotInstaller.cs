using Baraboom.Game.Characters.Bots.StateMachine;
using Baraboom.Game.Characters.Bots.StateMachine.Conditions;
using Baraboom.Game.Characters.Bots.StateMachine.States;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
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
		}

		#endregion

		#region interior

		private void InstallConditions()
		{
			Container.BindIFactory<BotConditionPlayerIsReachable>();
			Container.BindIFactory<BotConditionPlayerIsVisible>();
		}

		private void InstallStates()
		{
			Container.BindIFactory<BotStateNone>();
			Container.BindIFactory<BotStateRoaming>();
			Container.BindIFactory<BotStateChasing>();
		}

		private void InstallFactories()
		{
			Container.Bind<IConditionFactory>().To<BotConditionFactory>().AsSingle();
			Container.Bind<IStateFactory>().To<BotStateFactory>().AsSingle();
		}

		#endregion
	}
}