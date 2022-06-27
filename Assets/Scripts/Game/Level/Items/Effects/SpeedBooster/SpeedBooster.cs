using UnityEngine;

namespace Baraboom.Game.Level.Items
{
	public class SpeedBooster : Effect<ISpeedBoosterRecipient>
	{
		[SerializeField] private int _increase;

		protected override void Apply(ISpeedBoosterRecipient recipient)
		{
			recipient.BoostSpeed(_increase);
		}
	}
}