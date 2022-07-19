using System;
using UnityEngine;

namespace Baraboom.Game.Bombs.BombSpawner
{
	public interface IBombSpawner
	{
		event Action BombExploded;

		int DamageMultiplier { set; }
		int RangeIncrease { set; }

		void SpawnBomb(Vector3Int position);
	}
}