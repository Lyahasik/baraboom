namespace Baraboom.Game.Level.Items
{
	public interface IDamageBoosterRecipient : IEffectRecipient
	{
		void BoostDamage(int increase);
	}
}