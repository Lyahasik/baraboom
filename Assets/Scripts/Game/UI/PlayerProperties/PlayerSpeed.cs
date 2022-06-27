using Baraboom.Game.UI.Protocols;

namespace Baraboom.Game.UI
{
	public class PlayerSpeed : PlayerProperty
	{
		protected override int GetCount(IObservablePlayerData data)
		{
			return (int)data.Speed;
		}
	}
}