using System;
using Baraboom.Game.Level;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Bombs
{
	public class Bomb : Block, IBomb
	{
		#region facade

		event Action IBomb.Exploded
		{
			add => _exploded += value;
			remove => _exploded -= value;
		}

		int IBomb.Damage {  set => _damage = value; }
		int IBomb.Range {  set => _range = value; }

		#endregion

		#region interior

		[SerializeField] private GameObject _explosionPrefab;
		[SerializeField] private float _delay;

		private Logger _logger;
		private Action _exploded;
		private float _timeExplosion;
		private int _range;
		private int _damage;

		protected override void Awake()
		{
			base.Awake();

			_logger = Logger.For<Bomb>();
		}

		protected override void Start()
		{
			base.Start();

			_logger.Log("Spawned at {0}", DiscretePosition);
			Invoke(nameof(Explode), _delay);
		}

		private void Explode()
		{
			_logger.Log("Exploding at {0}", DiscretePosition);

			var explosionObject = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

			var explosion = explosionObject.GetComponent<IExplosion>();
			explosion.Damage = _damage;
			explosion.Range = _range;

			_exploded?.Invoke();
			Destroy(gameObject);
		}

		#endregion
	}
}