using Baraboom.Game.Bombs;
using UnityEngine;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Bots
{
	public class BotData : MonoBehaviour, IBombTarget
	{
		#region facade

		public void TakeDamage(int value)
		{
			_health -= value;
			_logger.Log("Took {0} damage.", value);

			if (_health <= 0)
			{
				_logger.Log("Died.");

				GetComponentInChildren<Animator>().SetTrigger(_animationDieId);
                
				Destroy(gameObject, _delayDie);
			}
		}

		#endregion

		#region interior
		
		private readonly int _animationDieId = Animator.StringToHash("Die");

		[SerializeField] private int _baseHealth;
		[SerializeField] private int _delayDie;

		private Logger _logger;
		private int _health;

		private void Awake()
		{
			_logger = Logger.For<BotData>();

			_health = _baseHealth;
		}

		#endregion
	}
}