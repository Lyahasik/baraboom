namespace Baraboom.Game.Items
{
	public interface ISpeedBoosterRecipient : IEffectRecipient
	{
		void BoostSpeed(float multiplier);
	}
}