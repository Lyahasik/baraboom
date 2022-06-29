using Baraboom.MainMenu.UI;
using Zenject;

namespace Baraboom.MainMenu
{
	public class MainMenuInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<PageGroup>()
			         .FromComponentInHierarchy()
			         .AsSingle();
		}
	}
}