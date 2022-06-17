using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Units
{
	[RequireComponent(typeof(DiscreteCollider))]
	public class BotAttackUnit : MonoBehaviour
	{
		[SerializeField] private int _damage;
		[SerializeField] private float _pauseAfterSuccessfulAttack;

		private bool _isPaused;

		[UsedImplicitly]
		private void OnDiscreteCollision(DiscreteCollider other)
		{
			if (_isPaused)
				return;

			var damageable = other.GetComponent<IBotTarget>();
			if (damageable != null)
			{
				damageable.TakeDamage(_damage);
				Pause();
			}
		}

		private void Pause()
		{
			_isPaused = true;
			Invoke(nameof(ClosePause), _pauseAfterSuccessfulAttack);
		}

		private void ClosePause()
		{
			_isPaused = false;
		}
	}
}