using Baraboom.Game.UI.Protocols;

namespace Baraboom.Game.UI
{
	public class PlayerExplosionRange : PlayerProperty
	{
		protected override int GetCount(IObservablePlayerData data)
		{
			return data.ExplosionRange;
		}
	}
}