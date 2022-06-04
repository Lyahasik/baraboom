using System;
using UnityEngine;

namespace Baraboom.Game.Bombs
{
	public class Bomb : MonoBehaviour, IBomb
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

		private Action _exploded;
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
			explosion.Damage = _damage;
			explosion.Range = _range;

			_exploded?.Invoke();
			Destroy(gameObject);
		}

		#endregion
	}
}