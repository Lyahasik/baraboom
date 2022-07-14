using System.Linq;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots.Units
{
	public class BotAttackUnit : Killer<IBotTarget>, IBotChasingData, IBotPlayerObserver
	{
		#region facade

		float IBotChasingData.DecisionPause => _decisionPause;

		bool IBotPlayerObserver.IsPlayerReachable
		{
			get
			{
				if (_player.IsNull())
					return false;

				return _pathFinder.FindPath(_controller.Position, _player.Position) != null;
			}
		}

		bool IBotPlayerObserver.IsPlayerVisible
		{
			get
			{
				if (_player.IsNull())
					return false;

				var botPosition = _controller.Position;
				var playerPosition = _player.Position;

				if (botPosition == playerPosition)
					return true;

				var colliders = _rayCaster.CastRay2D(botPosition, playerPosition).ToArray();
				if (colliders.Length == 0)
				{
					Logger.For<BotAttackUnit>().LogWarning("Ray haven't collided with any entity!");
					return false;
				}

				return colliders.First().Transform.DiscretePosition == playerPosition;
			}
		}

		#endregion

		#region interior

		[SerializeField] private new int _damage;
		[SerializeField] private new float _ignoreTargetDuration;
		[SerializeField] private float _decisionPause;

		[Inject] private IObservablePlayer _player;
		[Inject] private IBotController _controller;
		[Inject] private IBotPathFinder _pathFinder;
		[Inject] private DiscreteRayCaster _rayCaster;

		private void Awake()
		{
			base._damage = this._damage;
			base._ignoreTargetDuration = this._ignoreTargetDuration;
		}

		[UsedImplicitly]
		private void Terminate()
		{
			Destroy(this);
		}

		#endregion
	}
}