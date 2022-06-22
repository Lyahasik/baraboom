using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Characters.Bots.Tools;
using Baraboom.Game.Characters.Bots.Tools.Navigation;
using Baraboom.Game.Characters.Bots.Tools.StateMachine;
using Baraboom.Game.Tools.Collections;
using Baraboom.Game.Tools.Extensions;
using JetBrains.Annotations;
using Zenject;

namespace Baraboom.Game.Characters.Bots.StateMachine.States
{
	[UsedImplicitly]
	public class BotStateRoaming : BotState
	{
		#region facade

		protected override void OnInitialized()
		{
			if (_botRoamingData is null)
				throw new StateMachineException("Bot doesn't support roaming behaviour.");

			_wayPoints = _botRoamingData.WayPoints;

			var result = FindClosestReachableWayPoint(out var closestWayPointIndex, out var pathToClosestWayPoint);
			if (!result)
				throw new StateMachineException("Initial reachable way point is not found.");

			_wayPointIterator = new BouncingIterator<WayPoint>(_wayPoints, closestWayPointIndex);

			if (IsBotMoving)
				RequestBotStop();
			else
				MoveBot(pathToClosestWayPoint);
		}

		protected override void OnUpdated()
		{
			if (!IsBotMoving)
			{
				if (TestNextWayPoint(out var path))
					MoveBot(path);
			}
		}

		#endregion

		#region interior

		[InjectOptional] private IBotRoamingData _botRoamingData;

		private WayPoint[] _wayPoints;
		private BouncingIterator<WayPoint> _wayPointIterator;

		private bool FindClosestReachableWayPoint(out int closestWayPointIndex, out Path pathToClosestWayPoint)
		{
			closestWayPointIndex = -1;
			pathToClosestWayPoint = null;

			foreach (var (wayPoint, index) in _wayPoints.Enumerate())
			{
				var path = PathFinder.FindPath(BotPosition, wayPoint.Position);
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

		private bool TestNextWayPoint(out Path pathToClosestWayPoint)
		{
			pathToClosestWayPoint = PathFinder.FindPath(BotPosition, _wayPointIterator.Next.Position);
			return pathToClosestWayPoint != null;
		}

		#endregion
	}
}