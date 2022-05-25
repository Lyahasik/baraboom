using UnityEngine;

namespace Baraboom.Effects
{
	public abstract class Effect<T> : MonoBehaviour, IEffect
	{
		public void TryApply(IEffectRecipient recipient)
		{
			if (recipient is T typedRecipient)
				Apply(typedRecipient);
		}

		protected abstract void Apply(T recipient);
	}
}