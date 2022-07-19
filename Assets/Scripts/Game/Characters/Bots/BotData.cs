using Baraboom.Game.Bombs;
using Baraboom.Game.Level;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots
{
	public class BotData : MonoBehaviour, IBombTarget
	{
		#region facade

		public void TakeDamage(int value)
		{
			if (_health <= 0)
			{
				_logger.Log("Ignored {0} damage.", value);
				return;
			}

			_health -= value;
			_logger.Log("Took {0} damage.", value);

			_characterEffects.ActivateElectricityShader();

			if (_health <= 0)
			{
				_logger.Log("Died.");

				GetComponentInChildren<Animator>().SetTrigger(_animationDieId);
				BroadcastMessage("Terminate");

				_level.RemoveBot(gameObject);
				Destroy(gameObject, _delayDie);
			}
		}

		#endregion

		#region interior

		private readonly int _animationDieId = Animator.StringToHash("Die");

		[SerializeField] private int _baseHealth;
		[SerializeField] private int _delayDie;

		[Inject] private ILevel _level;
		
		private CharacterEffects _characterEffects;
		private Logger _logger;
		private int _health;

		private void Awake()
		{
			_logger = Logger.For<BotData>();
			_characterEffects = GetComponent<CharacterEffects>();

			_health = _baseHealth;
			_level.AddBot(gameObject);
		}

		#endregion
	}
}