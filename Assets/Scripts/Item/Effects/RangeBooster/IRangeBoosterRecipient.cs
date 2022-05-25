namespace Baraboom.Effects
{
	public interface IRangeBoosterRecipient : IEffectRecipient
	{
		void BoostRange(int increase);
	}
}