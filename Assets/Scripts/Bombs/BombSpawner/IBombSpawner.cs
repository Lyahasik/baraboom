using System;
using UnityEngine;

namespace Baraboom
{
	public interface IBombSpawner
	{
		public event Action BombExploded;

		public float DamageMultiplier { set; }
		public int RangeIncrease { set; }

		public void SpawnBomb(Vector3 position);
	}
}