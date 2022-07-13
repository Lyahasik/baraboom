using System;
using System.Collections;
using Baraboom.Game.Level;
using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;
using Zenject;

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

        [Inject] private ILevel _level;

        private IEnumerator Start()
        {
            for (var currentRange = 0; currentRange < Length; currentRange++)
            {
                var block = _level.BlockMap.GetBlock(DiscreteTranslator.ToDiscrete(transform.position));
                if (block is IExplosionSink)
                    break;

                ExplosionGenerator(transform.position);
                transform.position += Direction;

                yield return new WaitForSeconds(ExplosionUnitGap);
            }

            Destroy(gameObject);
        }

        #endregion
    }
}
