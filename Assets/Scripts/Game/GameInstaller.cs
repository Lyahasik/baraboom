using Baraboom.Core.Tools.Extensions;
using Baraboom.Game.Bombs;
using Baraboom.Game.Bombs.Bomb;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools;
using Baraboom.Game.Characters.Player;
using Baraboom.Game.Characters.Player.PlayerInput;
using Baraboom.Game.Data;
using Baraboom.Game.Level;
using Baraboom.Game.Level.Environment;
using Baraboom.Game.Level.Items;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DI;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.UI;
using Baraboom.Game.UI.Protocols;
using UnityEngine;
using Zenject;

namespace Baraboom.Game
{
	public class GameInstaller : MonoInstaller
	{
		#region facade

		public override void InstallBindings()
		{
			InstallData();
			InstallGame();
			InstallDiscreteWorld();
			InstallLevel();
			InstallPlayer();
			InstallBot();
			InstallUI();
		}

		#endregion

		#region interior

		[SerializeField] private Dialog _pauseDialog;

		private void InstallData()
		{
			Container.Bind<LevelData>()
			         .FromComponentInHierarchy()
			         .AsSingle();
		}

		private void InstallGame()
		{
			var @object = gameObject.AddChild("Game");

			Container.Bind<PauseState>()
			         .FromNewComponentOn(@object)
			         .AsSingle();

			Container.Bind<GameController>()
			         .FromNewComponentOn(@object)
			         .AsSingle();

			Container.Bind<GameEvents>()
			         .FromNewComponentOn(@object)
			         .AsSingle();
		}

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

			Container.BindIFactory<Object, Vector3, Item>()
			         .FromFactory<PrefabFactoryWithPosition<Item>>();
		}

		private void InstallPlayer()
		{
			Container.Bind(typeof(IObservablePlayer), typeof(IObservablePlayerData), typeof(IControllablePlayer))
			         .To<PlayerData>()
			         .FromComponentInHierarchy()
			         .AsSingle();

			Container.Bind<IPlayerInputReceiver>()
			         .FromComponentsInHierarchy()
			         .AsCached();

			Container.BindIFactory<Object, Vector3, Bomb>()
			         .FromFactory<PrefabFactoryWithPosition<Bomb>>();

			Container.BindIFactory<Object, Vector3, Explosion>()
			         .FromFactory<PrefabFactoryWithPosition<Explosion>>();
			
			Container.BindIFactory<Object, Vector3, LightingExplosion>()
			         .FromFactory<PrefabFactoryWithPosition<LightingExplosion>>();
			
			Container.BindIFactory<Object, Vector3, ExplosionUnit>()
				.FromFactory<PrefabFactoryWithPosition<ExplosionUnit>>();
		}

		private void InstallBot()
		{
			var @object = gameObject.AddChild("Bot");

			Container.Bind<WayPoint>()
			         .FromComponentsInHierarchy()
			         .AsSingle();

			Container.Bind<WayPointProvider>()
			         .FromNewComponentOn(@object)
			         .AsSingle();
		}

		private void InstallUI()
		{
			Container.Bind<Dialog>()
			         .WithId("pause")
			         .FromInstance(_pauseDialog)
			         .AsSingle();

			Container.Bind<TouchController>()
			         .FromComponentInHierarchy()
			         .AsSingle();
		}

		#endregion
	}
}