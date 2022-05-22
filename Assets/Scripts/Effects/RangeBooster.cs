using UnityEngine;

namespace Baraboom.Effects
{
	public class RangeBooster : TemporaryEffect
	{
		[SerializeField] private int _increase;

		protected override void StartEffect(IPlayer player)
		{
			player.BoostRange(_increase);
		}

		protected override void StopEffect(IPlayer player)
		{
			player.ResetRange();
		}
	}
}