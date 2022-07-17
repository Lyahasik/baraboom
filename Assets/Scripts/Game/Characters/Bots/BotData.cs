using System;
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
			_health -= value;
			_logger.Log("Took {0} damage.", value);
			
			EnableElectricity();

			if (_health <= 0)
			{
				_logger.Log("Died.");

				GetComponentInChildren<Animator>().SetTrigger(_animationDieId);
				BroadcastMessage("Terminate");
				
				_level.RemoveBot(gameObject);
				Destroy(gameObject, _delayDie);
			}
		}

		private void Update()
		{
			DisableElectricity();
		}

		private void DisableElectricity()
		{
			if (_electricityOffTime > Time.time
			    || _materials[1] == null)
				return;
			
			_materials[1] = null;
			_meshRenderer.materials = _materials;
		}

		private void EnableElectricity()
		{
			_electricityOffTime = Time.time + _durationElectricity;
			
			_materials[1] = _materialElectricity;
			_meshRenderer.materials = _materials;
		}

		#endregion

		#region interior

		private readonly int _animationDieId = Animator.StringToHash("Die");

		[SerializeField] private int _baseHealth;
		[SerializeField] private int _delayDie;
		[SerializeField] private float _durationElectricity;

		[Inject] private ILevel _level;
		
		private MeshRenderer _meshRenderer;
		private Material[] _materials;
		private Material _materialElectricity;
		private float _electricityOffTime;
		private Logger _logger;
		private int _health;

		private void Awake()
		{
			_logger = Logger.For<BotData>();

			_health = _baseHealth;
			_level.AddBot(gameObject);
		}

		private void Start()
		{
			_meshRenderer = GetComponentInChildren<MeshRenderer>();
			_materials = _meshRenderer.materials;
			_materialElectricity = _materials[1];
		}

		#endregion
	}
}