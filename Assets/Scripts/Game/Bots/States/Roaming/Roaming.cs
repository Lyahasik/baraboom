using System.Collections.Generic;
using Baraboom.Game.Bots.Tools.PathFinder;
using Baraboom.Game.Bots.Tools.StateMachine;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Bots.States
{
	public class Roaming : IState
	{
		#region facade

		public Roaming(IControllableBot bot)
		{
			_bot = bot;
		}

		IEnumerable<ITransition> IState.Transitions
		{
			get
			{
				yield break;
			}
		}

		void IState.Initialize()
		{
			var level = GameObject.Find("Level").GetComponent<ILevel>(); // TODO Injection
			_pathFinder = new PathFinder(level);

			if (FindClosestWayPoint(out var closestWayPointIndex, out var pathToClosestWayPoint))
			{
				_targetWayPointIndex = closestWayPointIndex;
				_bot.MoveAlongPath(pathToClosestWayPoint);
			}
		}
		
		void IState.Deinitialize()
		{
			_pathFinder.Dispose();
		}

		void IState.Update()
		{
			if (!_bot.IsMoving)
			{
				_targetWayPointIndex = Array.LoopIncrement(_targetWayPointIndex, _bot.WayPoints.Length);

				var path = _pathFinder.FindPath(_bot.Position, _bot.WayPoints[_targetWayPointIndex].Position);
				if (path != null)
					_bot.MoveAlongPath(path);
			}
		}

		#endregion

		#region interior

		private readonly IControllableBot _bot;
		private PathFinder _pathFinder;
		private int _targetWayPointIndex;

		private bool FindClosestWayPoint(out int closestWayPointIndex, out Vector2Int[] pathToClosestWayPoint)
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

		#endregion
	}
}