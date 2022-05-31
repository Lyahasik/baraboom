using System;
using UnityEngine;

namespace Baraboom
{
	public interface IBombSpawner
	{
		event Action BombExploded;

		int DamageMultiplier { set; }
		int RangeIncrease { set; }

		void SpawnBomb(Vector3 position);
	}
}