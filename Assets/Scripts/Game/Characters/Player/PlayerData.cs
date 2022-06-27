using System;
using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Level.Items;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.UI.Protocols;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Characters.Player
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
		IObservablePlayer,
		IObservablePlayerData
	{
		#region facade

		void ITarget.TakeDamage(int value)
		{
			_health -= value;
			_propertyChanged?.Invoke();

			_logger.Log("Took {0} damage.", value);

			if (_health <= 0)
			{
				_logger.Log("Died.");
				Destroy(gameObject);
			}
		}

		void IAdditionalPlantingSlotRecipient.AddPlantingSlot()
		{
			_plantingSlots++;
			_propertyChanged?.Invoke();
		}

		void IDamageBoosterRecipient.BoostDamage(int increase)
		{
			_explosionDamage += increase;
			_propertyChanged?.Invoke();
		}

		void IHealRecipient.Heal(int amount)
		{
			_health = Mathf.Min(_health + amount, _baseHealth);
			_propertyChanged?.Invoke();
		}

		void IRangeBoosterRecipient.BoostRange(int increase)
		{
			_explosionRange += increase;
			_propertyChanged?.Invoke();
		}

		void ISpeedBoosterRecipient.BoostSpeed(int increase)
		{
			_speedLevel += increase;
			_propertyChanged?.Invoke();
		}

		int IControllablePlayer.ExplosionDamage => _explosionDamage;

		int IControllablePlayer.ExplosionRange => _explosionRange;

		float IControllablePlayer.Speed => ConvertSpeedLevelToSpeed(_speedLevel);

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

		Vector3Int IObservablePlayer.Position
		{
			get => GetComponent<DiscreteTransform>().DiscretePosition;
		}

		event Action IObservablePlayerData.Changed
		{
			add => _propertyChanged += value;
			remove => _propertyChanged -= value;
		}

		int IObservablePlayerData.Health => _health;

		int IObservablePlayerData.SpeedLevel => _speedLevel;

		int IObservablePlayerData.PlantingSlots => _plantingSlots;

		int IObservablePlayerData.ExplosionDamage => _explosionDamage;

		int IObservablePlayerData.ExplosionRange => _explosionRange;

		#endregion

		#region interior

		[SerializeField] private int _baseHealth;
		[SerializeField] private int _baseSpeedLevel;
		[SerializeField] private int _basePlantingSlots;
		[SerializeField] private int _baseExplosionDamage;
		[SerializeField] private int _baseExplosionRange;

		private Logger _logger;
		private int _health;
		private int _speedLevel;
		private int _plantingSlots;
		private int _plantedBombsCount;
		private int _explosionDamage;
		private int _explosionRange;
		private Action _propertyChanged;

		private void Awake()
		{
			_logger = Logger.For<PlayerData>();

			_health = _baseHealth;
			_speedLevel = _baseSpeedLevel;
			_plantingSlots = _basePlantingSlots;
			_explosionDamage = _baseExplosionDamage;
			_explosionRange = _baseExplosionRange;
		}

		private static float ConvertSpeedLevelToSpeed(int speedLevel)
		{
			return 1f + (speedLevel - 1) * 0.1f;
		}

		#endregion
	}
}