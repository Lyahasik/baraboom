namespace Baraboom.Effects
{
	public interface ISpeedBoosterRecipient : IEffectRecipient
	{
		void BoostSpeed(float multiplier);
	}
}