namespace Baraboom.Effects
{
	public interface IHealRecipient : IEffectRecipient
	{
		void Heal(int amount);
	}
}