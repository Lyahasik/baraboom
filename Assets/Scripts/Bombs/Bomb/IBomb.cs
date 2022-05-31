using System;

namespace Baraboom
{
	public interface IBomb
	{
		event Action Exploded;

		int Damage { set; }
		int Range { set; }
	}
}