using System;
using UnityEngine;

namespace Environment
{
    public class SpawnerBombs : MonoBehaviour
    {
        public GameObject SpawnBomb(Vector3 playerPosition, GameObject prefabBomb, int damage)
        {
            Vector3 bombPosition = new Vector3((float)Math.Truncate(playerPosition.x), 0.0f, (float)Math.Truncate(playerPosition.z));

            GameObject bomb = Instantiate(prefabBomb, bombPosition, Quaternion.identity);
            bomb.GetComponent<Bomb>().Damage = damage;
            
            return bomb;
        }
    }
}
