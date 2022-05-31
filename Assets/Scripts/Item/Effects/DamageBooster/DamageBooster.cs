using UnityEngine;

namespace Baraboom.Effects
{
	public class DamageBooster : Effect<IDamageBoosterRecipient>
	{
		[SerializeField] private int _increase;

		protected override void Apply(IDamageBoosterRecipient recipient)
		{
			recipient.BoostDamage(_increase);
		}
	}
}