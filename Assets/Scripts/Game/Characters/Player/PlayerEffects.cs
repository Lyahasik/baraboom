using Baraboom.Core.Data;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Characters.Player
{
	[RequireComponent(typeof(IPlayerEvents))]
	public class PlayerEffects : MonoBehaviour
	{
		private readonly int _animationDieId = Animator.StringToHash("Die");

		[SerializeField] private int _destroyDelay;
		[SerializeField] private AudioSource _powerUpSound;
		[SerializeField] private AudioSource _damageSound;

		[Inject] private PlayerPreferences _preferences;

		private void Awake()
		{
			var playerEvents = GetComponent<IPlayerEvents>();
			playerEvents.Died += OnDied;
			playerEvents.ReceivedDamage += OnReceivedDamage;
			playerEvents.ReceivedPowerUp += OnReceivedPowerUp;
		}

		private void OnDied()
		{
			GetComponentInChildren<Animator>().SetTrigger(_animationDieId);
			Destroy(gameObject, _destroyDelay);
		}

		private void OnReceivedDamage()
		{
			if (_preferences.Sound)
				_damageSound.Play();
		}

		private void OnReceivedPowerUp()
		{
			if (_preferences.Sound)
				_powerUpSound.Play();
		}
	}
}