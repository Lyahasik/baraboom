using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Level;
using UnityEngine;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Game.Characters.Bots.Units
{
	public class BotNavigationUnit : MonoBehaviour, IBotPathFinder
	{
		#region facade

		public Path FindPath(Vector2Int start, Vector2Int target)
		{
			try
			{
				var startBlock = _descriptor.GetBlock(start);
				var targetBlock = _descriptor.GetBlock(target);

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

		private ILevel _level;
		private LevelDescriptor _descriptor;

		private void Awake()
		{
			_level = GameObject.Find("Level").GetComponent<ILevel>(); // TODO Inject
			_level.Changed += OnLevelChanged;

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