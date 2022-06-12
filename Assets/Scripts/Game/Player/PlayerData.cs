using System;
using Baraboom.Game.Bombs;
using Baraboom.Game.Bots;
using Baraboom.Game.Items;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Player
{
	[RequireComponent(typeof(DiscreteTransform))]
	public class PlayerData :
		MonoBehaviour,
		IBombTarget,
		IBotTarget,
		IAdditionalPlantingSlotRecipient,
		IDamageBoosterRecipient,
		IHealRecipient,
		IRangeBoosterRecipient,
		ISpeedBoosterRecipient,
		IControllablePlayer,
		IObservablePlayer
	{
		#region facade

		void IBombTarget.TakeDamage(int value)
		{
			TakeDamage(value, "bomb");
		}

		void IBotTarget.TakeDamage(int value)
		{
			TakeDamage(value, "bot");
		}

		void IAdditionalPlantingSlotRecipient.AddPlantingSlot()
		{
			_plantingSlots++;
		}

		void IDamageBoosterRecipient.BoostDamage(int increase)
		{
			_explosionDamage += increase;
		}

		void IHealRecipient.Heal(int amount)
		{
			_health = Mathf.Min(_health + amount, _baseHealth);
		}

		void IRangeBoosterRecipient.BoostRange(int increase)
		{
			_explosionRange += increase;
		}

		void ISpeedBoosterRecipient.BoostSpeed(float multiplier)
		{
			_speed = _baseSpeed * multiplier;
		}

		int IControllablePlayer.ExplosionDamage => _explosionDamage;

		int IControllablePlayer.ExplosionRange => _explosionRange;

		float IControllablePlayer.Speed => _speed;

		bool IControllablePlayer.HaveBombs => _plantedBombsCount < _plantingSlots;

		void IControllablePlayer.AddPlantedBomb()
		{
			_plantedBombsCount++;
		}

		void IControllablePlayer.RemovePlantedBomb()
		{
			_plantedBombsCount--;
		}

		event Action IObservablePlayer.PositionChanged
		{
			add => GetComponent<DiscreteTransform>().DiscretePositionChanged += value;
			remove => GetComponent<DiscreteTransform>().DiscretePositionChanged -= value;
		}

		Vector2Int IObservablePlayer.Position
		{
			get => GetComponent<DiscreteTransform>().DiscretePosition.XY();
		}

		#endregion

		#region interior

		[SerializeField] private int _baseHealth;
		[SerializeField] private float _baseSpeed;
		[SerializeField] private int _basePlantingSlots;
		[SerializeField] private int _baseExplosionDamage;
		[SerializeField] private int _baseExplosionRange;

		private Logger _logger;
		private int _health;
		private float _speed;
		private int _plantingSlots;
		private int _plantedBombsCount;
		private int _explosionDamage;
		private int _explosionRange;

		private void Awake()
		{
			_logger = Logger.For<PlayerData>();

			_health = _baseHealth;
			_speed = _baseSpeed;
			_plantingSlots = _basePlantingSlots;
			_explosionDamage = _baseExplosionDamage;
			_explosionRange = _baseExplosionRange;
		}

		private void TakeDamage(int value, string attacker)
		{
			_health -= value;
			_logger.Log("Took {0} damage from {1}", value, attacker);

			if (_health <= 0)
			{
				_logger.Log("Died.");
				Destroy(gameObject);
			}
		}

		#endregion
	}
}