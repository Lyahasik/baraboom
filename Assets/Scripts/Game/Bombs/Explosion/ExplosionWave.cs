using System;
using System.Collections;
using UnityEngine;

namespace Baraboom.Game.Bombs
{
    public class ExplosionWave : MonoBehaviour
    {
        #region facade

        public Vector3 Direction { private get; set; }
        public int Length { private get; set; }
        public Action<Vector3> ExplosionGenerator { private get; set; }
        public float ExplosionUnitGap { private get; set; }

        #endregion
        
        #region interior

        private IEnumerator Start()
        {
            for (var currentRange = 0; currentRange < Length; currentRange++)
            {
                ExplosionGenerator(transform.position);
                transform.position += Direction;

                yield return new WaitForSeconds(ExplosionUnitGap);
            }

            Destroy(gameObject);
        }

        #endregion
    }
}
