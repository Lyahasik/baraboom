using Baraboom.Effects;
using UnityEngine;

namespace Baraboom
{
	public class Player :
		MonoBehaviour,
		IDamageable,
		IAdditionalPlantingSlotRecipient,
		IDamageBoosterRecipient,
		IHealRecipient,
		IRangeBoosterRecipient,
		ISpeedBoosterRecipient,
		IControllablePlayer
	{
		#region facade

		void IDamageable.TakeDamage(float value)
		{
			_health -= value;
			if (_health <= 0)
				Destroy(gameObject);
		}

		void IAdditionalPlantingSlotRecipient.AddPlantingSlot()
		{
			_plantingSlots++;
		}

		void IDamageBoosterRecipient.BoostDamage(float multiplier)
		{
			_damageMultiplier = multiplier;
		}

		void IHealRecipient.Heal(int amount)
		{
			_health = Mathf.Min(_health + amount, _baseHealth);
		}

		void IRangeBoosterRecipient.BoostRange(int increase)
		{
			_rangeIncrease = increase;
		}

		void ISpeedBoosterRecipient.BoostSpeed(float multiplier)
		{
			_speed = _baseSpeed * multiplier;
		}

		float IControllablePlayer.DamageMultiplier => _damageMultiplier;
		
		int IControllablePlayer.RangeIncrease => _rangeIncrease;

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

		#endregion

		#region interior

		[SerializeField] private float _baseHealth;
		[SerializeField] private float _baseSpeed;
		[SerializeField] private int _basePlantingSlots;

		private float _health;
		private float _speed;
		private int _plantingSlots;
		private int _plantedBombsCount;
		private float _damageMultiplier;
		private int _rangeIncrease;

		private void Awake()
		{
			_health = _baseHealth;
			_speed = _baseSpeed;
			_plantingSlots = _basePlantingSlots;

			_damageMultiplier = 1f;
		}

		#endregion
	}
}