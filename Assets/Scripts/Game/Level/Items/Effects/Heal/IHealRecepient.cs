
namespace Baraboom.Game.Level.Items
{
	public interface IHealRecipient : IEffectRecipient
	{
		void Heal(int amount);
	}
}