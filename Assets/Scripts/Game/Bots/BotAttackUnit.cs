using Baraboom.Game.Bombs;
using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Bots
{
	public class BotAttackUnit : DiscreteCollider
	{
		#region facade

		public override void OnCollision(DiscreteCollider other)
		{
			if (_isPaused)
				return;

			var damageable = other.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(_damage);
				Pause();
			}
		}

		#endregion

		#region interior

		[SerializeField] private int _damage;
		[SerializeField] private float _pauseAfterSuccessfulAttack;

		private bool _isPaused;

		private void Pause()
		{
			_isPaused = true;
			Invoke(nameof(ClosePause), _pauseAfterSuccessfulAttack);
		}

		private void ClosePause()
		{
			_isPaused = false;
		}

		#endregion
	}
}