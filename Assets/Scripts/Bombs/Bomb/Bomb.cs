using System;
using UnityEngine;

namespace Baraboom
{
	public class Bomb : MonoBehaviour, IBomb
	{
		#region facade

		event Action IBomb.Exploded
		{
			add => _exploded += value;
			remove => _exploded -= value;
		}

		float IBomb.DamageMultiplier {  set => _damageMultiplier = value; }
		int IBomb.RangeIncrease {  set => _rangeIncrease = value; }

		#endregion

		#region interior

		[SerializeField] private GameObject _explosionPrefab;
		[SerializeField] private float _delay;

		private Action _exploded;
		private float _damageMultiplier;
		private int _rangeIncrease;
		private float _timeExplosion;
		private int _range;
		private int _damage;

		private void Awake()
		{
			_damageMultiplier = 1;
		}

		private void Start()
		{
			Invoke(nameof(Explode), _delay);
		}

		private void Explode()
		{
			var explosionObject = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

			var explosion = explosionObject.GetComponent<IExplosion>();
			explosion.DamageMultiplier = _damageMultiplier;
			explosion.RangeIncrease = _rangeIncrease;

			_exploded?.Invoke();
			Destroy(gameObject);
		}

		#endregion
	}
}