namespace Baraboom.Game.Items
{
	public interface IRangeBoosterRecipient : IEffectRecipient
	{
		void BoostRange(int increase);
	}
}