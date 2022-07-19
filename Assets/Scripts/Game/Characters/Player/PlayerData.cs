using System;
using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Bots.Protocols;
using Baraboom.Game.Level.Items;
using Baraboom.Game.Tools;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.UI.Protocols;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

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
		IPlayerEvents,
		IObservablePlayer,
		IObservablePlayerData
	{
		#region facade

		void ITarget.TakeDamage(int value)
		{
			if (_health <= 0)
			{
				_logger.Log("Ignored {0} damage.", value);
				return;
			}

			_logger.Log("Took {0} damage.", value);

			_health -= value;

			_playerEffects.ActivateElectricityShader();
			_propertyChanged?.Invoke();
			_receivedDamage?.Invoke();

			if (_health <= 0)
			{
				_logger.Log("Died.");

				BroadcastMessage("Terminate");

				_died?.Invoke();
				_gameEvents.InvokeDefeat();
			}
		}

		void IAdditionalPlantingSlotRecipient.AddPlantingSlot()
		{
			_plantingSlots++;

			_propertyChanged?.Invoke();
			_receivedPowerUp?.Invoke();
		}

		void IDamageBoosterRecipient.BoostDamage(int increase)
		{
			_explosionDamage += increase;

			_propertyChanged?.Invoke();
			_receivedPowerUp?.Invoke();
		}

		void IHealRecipient.Heal(int amount)
		{
			_health += amount;

			_propertyChanged?.Invoke();
			_receivedPowerUp?.Invoke();
		}

		void IRangeBoosterRecipient.BoostRange(int increase)
		{
			_explosionRange += increase;

			_propertyChanged?.Invoke();
			_receivedPowerUp?.Invoke();
		}

		void ISpeedBoosterRecipient.BoostSpeed(int increase)
		{
			_speedLevel += increase;

			_propertyChanged?.Invoke();
			_receivedPowerUp?.Invoke();
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

		event Action IPlayerEvents.Died
		{
			add => _died += value;
			remove => _died -= value;
		}

		event Action IPlayerEvents.ReceivedDamage
		{
			add => _receivedDamage += value;
			remove => _receivedDamage -= value;
		}

		event Action IPlayerEvents.ReceivedPowerUp
		{
			add => _receivedPowerUp += value;
			remove => _receivedPowerUp -= value;
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

		[Inject] private GameEvents _gameEvents;
		
		private PlayerEffects _playerEffects;
		private Logger _logger;
		private AudioSource _powerUpSound;
		private int _health;
		private int _speedLevel;
		private int _plantingSlots;
		private int _plantedBombsCount;
		private int _explosionDamage;
		private int _explosionRange;
		private Action _propertyChanged;
		private Action _died;
		private Action _receivedDamage;
		private Action _receivedPowerUp;

		private void Awake()
		{
			_logger = Logger.For<PlayerData>();
			_playerEffects = GetComponent<PlayerEffects>();

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