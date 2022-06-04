namespace Baraboom.Game.Items
{
	public interface IEffect
	{
		void TryApply(IEffectRecipient recipient);
	}
}