using UnityEngine;

namespace Baraboom.Effects
{
	public class DamageBooster : Effect<IDamageBoosterRecipient>
	{
		[SerializeField] private float _multiplier;

		protected override void Apply(IDamageBoosterRecipient recipient)
		{
			recipient.BoostDamage(_multiplier);
		}
	}
}