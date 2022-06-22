using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools;
using Baraboom.Game.Characters.Player;
using Baraboom.Game.Level;
using Baraboom.Game.Level.Environment;
using Baraboom.Game.Level.Items;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DI;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Zenject;

namespace Baraboom.Game
{
	public class BaraboomInstaller : MonoInstaller
	{
		#region facade

		public override void InstallBindings()
		{
			InstallDiscreteWorld();
			InstallLevel();
			InstallPlayer();
			InstallBot();
		}

		#endregion

		#region interior

		private void InstallDiscreteWorld()
		{
			var @object = gameObject.AddChild("DiscreteWorld");

			Container.Bind<DiscreteColliderRegistry>()
			         .FromNewComponentOn(@object)
			         .AsSingle();

			Container.InstantiateComponent<DiscreteCollisionDetector>(@object);

			Container.Bind<DiscreteRayCaster>()
			         .FromNewComponentOn(@object)
			         .AsSingle();
		}

		private void InstallLevel()
		{
			var @object = gameObject.AddChild("Level");

			Container.Bind<ILevel>()
			         .FromComponentInHierarchy()
			         .AsSingle();

			Container.Bind<IBlockRegistry>()
			         .To<BlockRegistry>()
			         .FromNewComponentOn(@object)
			         .AsSingle();

			Container.Bind<ItemStore>()
			         .FromComponentInHierarchy()
			         .AsSingle();
		}

		private void InstallPlayer()
		{
			Container.Bind(typeof(IObservablePlayer), typeof(IControllablePlayer))
			         .FromComponentInHierarchy()
			         .AsSingle();

			Container.BindIFactory<Object, Vector3, Bomb>()
			         .FromFactory<PrefabFactoryWithPosition<Bomb>>();

			Container.BindIFactory<Object, Vector3, Explosion>()
			         .FromFactory<PrefabFactoryWithPosition<Explosion>>();

			Container.BindIFactory<Object, Vector3, ExplosionUnit>()
			         .FromFactory<PrefabFactoryWithPosition<ExplosionUnit>>();
		}

		private void InstallBot()
		{
			var @object = gameObject.AddChild("Bot");

			Container.Bind<WayPoint>()
			         .FromComponentsInHierarchy()
			         .AsCached();

			Container.Bind<WayPointProvider>()
			         .FromNewComponentOn(@object)
			         .AsSingle();
		}

		#endregion
	}
}