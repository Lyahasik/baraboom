using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Level.Items
{
    [RequireComponent(typeof(DiscreteCollider))]
    public sealed class Item : MonoBehaviour
    {
        private IEffect _effect;

        private void Awake()
        {
            _effect = GetComponent<IEffect>();
        }

        [UsedImplicitly]
        private void OnDiscreteCollision(DiscreteCollider other)
        {
            var recipient = other.GetComponent<IEffectRecipient>();
            if (recipient != null)
            {
                _effect.TryApply(recipient);
                Destroy(gameObject);
            }
        }
    }
}
