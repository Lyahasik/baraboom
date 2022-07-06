using Baraboom.Core.Data;
using Zenject;

namespace Baraboom.Core
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<GameData>()
			         .FromScriptableObjectResource("GameData")
			         .AsSingle();

			Container.Bind<PlayerData>()
			         .FromNewComponentOn(gameObject)
			         .AsSingle();
		}
	}
}