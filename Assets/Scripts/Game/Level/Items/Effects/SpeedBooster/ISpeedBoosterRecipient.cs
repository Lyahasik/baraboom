namespace Baraboom.Game.Level.Items
{
	public interface ISpeedBoosterRecipient : IEffectRecipient
	{
		void BoostSpeed(float multiplier);
	}
}