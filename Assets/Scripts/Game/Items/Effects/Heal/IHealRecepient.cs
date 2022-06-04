
namespace Baraboom.Game.Items
{
	public interface IHealRecipient : IEffectRecipient
	{
		void Heal(int amount);
	}
}