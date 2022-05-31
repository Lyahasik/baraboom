namespace Baraboom.Effects
{
	public interface IDamageBoosterRecipient : IEffectRecipient
	{
		void BoostDamage(int increase);
	}
}