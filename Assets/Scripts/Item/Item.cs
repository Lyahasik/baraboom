using Baraboom.Effects;
using Tools;
using Tools.CollisionInversion;
using UnityEngine;

namespace Baraboom
{
    public class Item : MonoBehaviour, IInvertedTrigger
    {
        #region facade

        public void OnInvertedCollision(GameObject @object)
        {
            var player = @object.GetComponent<IPlayer>();
            if (player != null)
            {
                player.ToMonoBehaviour().StartCoroutine(_effect.Apply(player));
                Destroy(gameObject);
            }
        }

        #endregion

        #region interior

        private IEffect _effect;

        private void Awake()
        {
            _effect = GetComponent<IEffect>();
        }

        #endregion
    }
}
