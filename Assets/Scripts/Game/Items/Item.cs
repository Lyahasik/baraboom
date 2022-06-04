using Baraboom.Game.Tools;

namespace Baraboom.Game.Items
{
    public sealed class Item : DiscreteCollider
    {
        private IEffect _effect;

        protected override void Awake()
        {
            base.Awake();
            _effect = GetComponent<IEffect>();
        }

        public override void OnCollision(DiscreteCollider other)
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
