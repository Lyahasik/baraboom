namespace Baraboom.Effects
{
	public interface IEffect
	{
		void TryApply(IEffectRecipient recipient);
	}
}