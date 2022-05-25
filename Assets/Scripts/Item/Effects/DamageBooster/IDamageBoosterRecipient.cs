namespace Baraboom.Effects
{
	public interface IDamageBoosterRecipient : IEffectRecipient
	{
		void BoostDamage(float multiplier);
	}
}