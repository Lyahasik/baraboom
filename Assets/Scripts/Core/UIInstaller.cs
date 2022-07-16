using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.Core
{
	public class UIInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<UIAudioPlayer>()
			         .FromComponentInHierarchy()
			         .AsSingle();
		}
	}
}