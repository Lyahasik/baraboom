using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.Collections;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Bots.States
{
	public class Roaming : IState
	{
		#region facade

		void IState.Initialize(IContext abstractContext)
		{
			var context = (BotStateMachineContext)abstractContext;

			_pathFinder = context.PathFinder;

			_bot = context.Bot as IRoamingBot;
			if (_bot == null)
				throw new StateMachineException("Provided bot doesn't support roaming."); 

			var result = FindClosestReachableWayPoint(out var closestWayPointIndex, out var pathToClosestWayPoint);
			if (!result)
				throw new StateMachineException("Initial reachable way point is not found.");

			_wayPointIterator = new BouncingIterator<WayPoint>(_bot.WayPoints, closestWayPointIndex);
			_bot.Move(pathToClosestWayPoint);
		}
		
		void IState.Deinitialize() {}

		void IState.Update()
		{
			if (!_bot.IsMoving)
			{
				if (TestNextWayPoint(out var path))
					_bot.Move(path);
			}
		}

		#endregion

		#region interior

		private PathFinder _pathFinder;
		private IRoamingBot _bot;
		private BouncingIterator<WayPoint> _wayPointIterator;

		private bool FindClosestReachableWayPoint(out int closestWayPointIndex, out Vector2Int[] pathToClosestWayPoint)
		{
			closestWayPointIndex = -1;
			pathToClosestWayPoint = null;
			
			foreach (var (wayPoint, index) in _bot.WayPoints.Enumerate())
			{
				var path = _pathFinder.FindPath(_bot.Position, wayPoint.Position);
				if (path == null)
					continue;

				if (pathToClosestWayPoint == null || pathToClosestWayPoint.Length > path.Length)
				{
					pathToClosestWayPoint = path;
					closestWayPointIndex = index;
				}
			}

			return closestWayPointIndex != -1;
		}

		private bool TestNextWayPoint(out Vector2Int[] pathToClosestWayPoint)
		{
			pathToClosestWayPoint = _pathFinder.FindPath(_bot.Position, _wayPointIterator.Next.Position);
			return pathToClosestWayPoint != null;
		}

		#endregion
	}
}