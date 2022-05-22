using System;
using UnityEngine;

namespace Baraboom
{
	public class Player : MonoBehaviour, IPlayer
	{
		#region facade

		public float Speed => _speed;
		public float DamageMultiplier => _damageMultiplier;
		public int RangeIncrease => _rangeIncrease;
		public bool HaveBombs => _plantedBombsCount < _plantingSlots;

		public void TakeDamage(float value)
		{
			_health -= value;
			if (_health <= 0)
				Destroy(gameObject);
		}

		public void Heal(float amount)
		{
			_health = Mathf.Min(_health + amount, _baseHealth);
		}

		public void BoostSpeed(float multiplier)
		{
			_speed = _baseSpeed * multiplier;
		}

		public void ResetSpeed()
		{
			_speed = _baseSpeed;
		}

		public void BoostDamage(float multiplier)
		{
			_damageMultiplier = multiplier;
		}

		public void ResetDamage()
		{
			_damageMultiplier = 1f;
		}

		public void BoostRange(int increase)
		{
			_rangeIncrease = increase;
		}

		public void ResetRange()
		{
			_rangeIncrease = 0;
		}

		public void AddPlantingSlot()
		{
			_plantingSlots++;
		}

		public void RemovePlantingSlot()
		{
			_plantingSlots = Math.Min(_plantingSlots - 1, _basePlantingSlots);
		}

		public void AddPlantedBomb()
		{
			_plantedBombsCount++;
		}

		public void RemovePlantedBomb()
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