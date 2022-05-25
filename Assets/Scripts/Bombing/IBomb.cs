using System;

namespace Baraboom
{
	public interface IBomb
	{
		public event Action Exploded;

		public float DamageMultiplier { set; }
		public int RangeIncrease { set; }
	}
}