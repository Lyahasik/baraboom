using Baraboom.Game.Bombs;
using Baraboom.Game.Items;
using UnityEngine;

namespace Baraboom.Game.Player
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

		void IDamageable.TakeDamage(int value)
		{
			_health -= value;
			if (_health <= 0)
				Destroy(gameObject);
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

		#endregion

		#region interior

		[SerializeField] private int _baseHealth;
		[SerializeField] private float _baseSpeed;
		[SerializeField] private int _basePlantingSlots;
		[SerializeField] private int _baseExplosionDamage;
		[SerializeField] private int _baseExplosionRange;

		private int _health;
		private float _speed;
		private int _plantingSlots;
		private int _plantedBombsCount;
		private int _explosionDamage;
		private int _explosionRange;

		private void Awake()
		{
			_health = _baseHealth;
			_speed = _baseSpeed;
			_plantingSlots = _basePlantingSlots;
			_explosionDamage = _baseExplosionDamage;
			_explosionRange = _baseExplosionRange;
		}

		#endregion
	}
}