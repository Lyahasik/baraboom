using UnityEngine;

namespace Environment.Explosions
{
    public class DirectedWave
    {
        private Vector3 _direction;
        private int _maxRange;

        public DirectedWave(Vector3 direction, int maxRange)
        {
            _direction = direction;
            _maxRange = maxRange;
        }

        public Vector3 GetPositionCreateEffect(Vector3 positionHypocentre, int currentRange)
        {
            if (currentRange > _maxRange)
                return positionHypocentre;
            
            return positionHypocentre + _direction * currentRange;
        }
    }
}
