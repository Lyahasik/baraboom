using System;

namespace Baraboom.Game.Bombs
{
	public interface IBomb
	{
		event Action Exploded;

		int Damage { set; }
		int Range { set; }
	}
}