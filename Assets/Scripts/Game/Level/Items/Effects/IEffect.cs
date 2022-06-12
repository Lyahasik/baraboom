namespace Baraboom.Game.Level.Items
{
	public interface IEffect
	{
		void TryApply(IEffectRecipient recipient);
	}
}