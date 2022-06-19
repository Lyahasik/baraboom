using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Zenject;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Units
{
	public class BotNavigationUnit : MonoBehaviour, IBotPathFinder
	{
		#region facade

		public Path FindPath(Vector3Int start, Vector3Int target)
		{
			if (start.z != target.z)
			{
				_logger.LogError("Start and target position has different z value!");
				return null;
			}

			try
			{
				var startBlock = _descriptor.GetBlock(start.XY());
				var targetBlock = _descriptor.GetBlock(target.XY());

				var pathRaw = AStar.Solver.Solve(_descriptor, startBlock, targetBlock, EuclideanHeuristic);
				return new Path(pathRaw.Select(block => block.Position));
			}
			catch (AStar.PathNotFoundException)
			{
				return null;
			}
		}

		#endregion

		#region interior

		[Inject] private ILevel _level;

		private Logger _logger;
		private LevelDescriptor _descriptor;

		private void Awake()
		{
			_logger = Logger.For<BotNavigationUnit>();
			_level.Changed += OnLevelChanged;
		}

		private void Start()
		{
			FetchLevel();
		}

		private void OnDestroy()
		{
			_level.Changed -= OnLevelChanged;
		}

		private static float EuclideanHeuristic(BlockDescriptor a, BlockDescriptor b)
		{
			return Vector2.Distance(a.Position, b.Position);
		}

		private void FetchLevel()
		{
			_descriptor = new LevelDescriptor(_level.BlockMap);
		}

		private void OnLevelChanged()
		{
			FetchLevel();
		}

		#endregion
	}
}