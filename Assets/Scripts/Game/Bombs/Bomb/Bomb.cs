using System;
using Baraboom.Game.Level.Environment;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;
using Object = UnityEngine.Object;

namespace Baraboom.Game.Bombs.Bomb
{
	public class Bomb : Block
	{
		#region facade

		public override bool IsWalkable => false;

		public event Action Exploded;

		public int Damage
		{
			set => _damage = value;
		}

		public int Range
		{
			set => _range = value;
		}

		#endregion

		#region interior

		[SerializeField] private GameObject _explosionPrefab;
		[SerializeField] private float _delay;

		[Inject] private IFactory<Object, Vector3, Explosion> _explosionFactory;

		private Logger _logger;
		private float _timeExplosion;
		private int _range;
		private int _damage;

		protected override void Awake()
		{
			base.Awake();

			_logger = Logger.For<Bomb>();
			transform.rotation = Quaternion.Euler(90f, 0f, 0f);
		}

		private void Start()
		{
			_logger.Log("Spawned at {0}", DiscretePosition);
			Invoke(nameof(Explode), _delay);
		}

		private void Explode()
		{
			_logger.Log("Exploding at {0}", DiscretePosition);

			var explosion = _explosionFactory.Create(_explosionPrefab, transform.position);
			explosion.Damage = _damage;
			explosion.Range = _range;

			Exploded?.Invoke();
			Destroy(gameObject);
		}

		#endregion
	}
}