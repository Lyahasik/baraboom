using Baraboom.Game.UI.Protocols;

namespace Baraboom.Game.UI
{
	public class PlayerExplosionDamage : PlayerProperty
	{
		protected override int GetCount(IObservablePlayerData data)
		{
			return data.ExplosionDamage;
		}
	}
}