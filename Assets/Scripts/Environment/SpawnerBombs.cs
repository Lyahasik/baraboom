using System;
using UnityEngine;

using Items;

namespace Environment
{
    public class SpawnerBombs : MonoBehaviour
    {
        public GameObject SpawnBomb(Vector3 playerPosition, GameObject prefabBomb, int range)
        {
            Vector3 bombPosition = new Vector3((float)Math.Round(playerPosition.x), 0.0f, (float)Math.Round(playerPosition.z));

            GameObject bomb = Instantiate(prefabBomb, bombPosition, Quaternion.identity);
            bomb.GetComponent<Bomb>().Init(range);
            
            return bomb;
        }
    }
}
