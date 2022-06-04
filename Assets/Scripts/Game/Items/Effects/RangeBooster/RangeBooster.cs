using UnityEngine;

namespace Baraboom.Game.Items
{
	public class RangeBooster : Effect<IRangeBoosterRecipient>
	{
		[SerializeField] private int _increase;

		protected override void Apply(IRangeBoosterRecipient recipient)
		{
			recipient.BoostRange(_increase);
		}
	}
}