using Baraboom;
using UnityEngine;

namespace Baraboom.Effects
{
	public class SpeedBooster : TemporaryEffect
	{
		[SerializeField] private float _multiplier;
		protected override void StartEffect(IPlayer player)
		{
			player.BoostSpeed(_multiplier);
		}

		protected override void StopEffect(IPlayer player)
		{
			player.ResetSpeed();
		}
	}
}