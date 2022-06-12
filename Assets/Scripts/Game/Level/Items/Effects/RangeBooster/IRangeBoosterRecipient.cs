namespace Baraboom.Game.Level.Items
{
	public interface IRangeBoosterRecipient : IEffectRecipient
	{
		void BoostRange(int increase);
	}
}