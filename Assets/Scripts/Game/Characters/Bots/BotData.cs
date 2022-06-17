using Baraboom.Game.Bombs;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

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
				Destroy(gameObject);
			}
		}

		#endregion

		#region interior

		[SerializeField] private int _baseHealth;

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