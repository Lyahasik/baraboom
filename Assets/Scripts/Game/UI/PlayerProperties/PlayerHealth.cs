using Baraboom.Game.UI.Protocols;

namespace Baraboom.Game.UI
{
	public class PlayerHealth : PlayerProperty
	{
		protected override int GetCount(IObservablePlayerData data)
		{
			return data.Health;
		}
	}
}