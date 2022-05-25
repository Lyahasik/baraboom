using UnityEngine;

namespace Baraboom.Effects
{
	public class Heal : Effect<IHealRecipient>
	{
		[SerializeField] private int _amount;

		protected override void Apply(IHealRecipient player)
		{
			player.Heal(_amount);
		}
	}
}