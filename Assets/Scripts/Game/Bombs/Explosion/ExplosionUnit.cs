using Baraboom.Game.Tools;
using UnityEngine;

namespace Baraboom.Game.Bombs
{
	public class ExplosionUnit : Killer<IBombTarget>
	{
		#region facade

		public int Damage
		{
			set => _damage = value;
		}

		public float IgnoreTargetDuration
		{
			set => _ignoreTargetDuration = value;
		}

		#endregion

		#region interior

		[SerializeField] private float _duration;

		private void Start()
		{
			Destroy(gameObject, _duration);
		}

		#endregion
	}
}