namespace Baraboom.Effects
{
	public interface IEffect
	{
		public void TryApply(IEffectRecipient recipient);
	}
}