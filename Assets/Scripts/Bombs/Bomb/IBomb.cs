using System;

namespace Baraboom
{
	public interface IBomb
	{
		event Action Exploded;

		float DamageMultiplier { set; }
		int RangeIncrease { set; }
	}
}