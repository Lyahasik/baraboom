using System;
using UnityEngine;

namespace Baraboom
{
	public interface IBombSpawner
	{
		event Action BombExploded;

		float DamageMultiplier { set; }
		int RangeIncrease { set; }

		void SpawnBomb(Vector3 position);
	}
}