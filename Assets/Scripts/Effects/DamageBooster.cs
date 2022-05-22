using Baraboom;
using UnityEngine;

namespace Baraboom.Effects
{
	public class DamageBooster : TemporaryEffect
	{
		[SerializeField] private float _multiplier;
		protected override void StartEffect(IPlayer player)
		{
			player.BoostDamage(_multiplier);
		}

		protected override void StopEffect(IPlayer player)
		{
			player.ResetDamage();
		}
	}
}