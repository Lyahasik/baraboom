using UnityEngine;

namespace Baraboom.Game.Level.Items
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