using Baraboom.Game.UI.Protocols;

namespace Baraboom.Game.UI
{
	public class PlayerPlantingSlots : PlayerProperty
	{
		protected override int GetCount(IObservablePlayerData data)
		{
			return data.PlantingSlots;
		}
	}
}