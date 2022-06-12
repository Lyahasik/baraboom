using System.Linq;
using Baraboom.Game.Level;
using UnityEngine;
using AStar = Baraboom.Game.Tools.Algorithms.AStar;

namespace Baraboom.Game.Bots.Tools.PathFinder
{
	public class PathFinder
	{
		#region facade

		public PathFinder(ILevel level)
		{
			_level = level;
			_level.Changed += OnLevelChanged;
			
			FetchLevel();
		}

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
		
		public void Dispose()
		{
			_level.Changed -= OnLevelChanged;
		}
		
		#endregion
	
		#region interior

		private readonly ILevel _level;
		private LevelDescriptor _descriptor;

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