using UnityEngine;

namespace Baraboom.Effects
{
	public class SpeedBooster : Effect<ISpeedBoosterRecipient>
	{
		[SerializeField] private float _multiplier;

		protected override void Apply(ISpeedBoosterRecipient recipient)
		{
			recipient.BoostSpeed(_multiplier);
		}
	}
}