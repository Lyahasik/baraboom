using Baraboom.Core.Data;
using Zenject;

namespace Baraboom.Core
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<PlayerProgress>()
			         .FromNewComponentOn(gameObject)
			         .AsSingle();
		}
	}
}