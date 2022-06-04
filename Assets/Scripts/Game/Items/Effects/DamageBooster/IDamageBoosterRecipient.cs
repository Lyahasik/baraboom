namespace Baraboom.Game.Items
{
	public interface IDamageBoosterRecipient : IEffectRecipient
	{
		void BoostDamage(int increase);
	}
}