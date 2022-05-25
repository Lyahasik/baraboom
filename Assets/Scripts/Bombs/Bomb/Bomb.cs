using System;
using UnityEngine;

namespace Baraboom
{
	public class Bomb : MonoBehaviour, IBomb
	{
		#region facade

		public event Action Exploded;

		public float DamageMultiplier { get; set; } = 1;
		public int RangeIncrease { get; set; }

		#endregion

		#region interior

		[SerializeField] private GameObject _explosionPrefab;
		[SerializeField] private float _delay;
		
		private float _timeExplosion;
		private int _range;
		private int _damage;
		
		private void Start()
		{
			Invoke(nameof(Explode), _delay);
		}

		private void Explode()
		{
			var explosionObject = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

			var explosion = explosionObject.GetComponent<IExplosion>();
			explosion.DamageMultiplier = DamageMultiplier;
			explosion.RangeIncrease = RangeIncrease;

			Exploded?.Invoke();
			Destroy(gameObject);
		}

		#endregion
	}
}