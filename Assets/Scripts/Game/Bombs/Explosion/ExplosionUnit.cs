using Baraboom.Game.Tools;

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

		private void Start()
		{
			Destroy(gameObject, _ignoreTargetDuration);
		}

		#endregion
	}
}