using Baraboom.Effects;
using Tools.CollisionInversion;
using UnityEngine;

namespace Baraboom
{
    public class Item : MonoBehaviour, IInvertedTrigger
    {
        #region facade

        public void OnInvertedCollision(GameObject @object)
        {
            var recipient = @object.GetComponent<IEffectRecipient>();
            if (recipient != null)
            {
                _effect.TryApply(recipient);
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
