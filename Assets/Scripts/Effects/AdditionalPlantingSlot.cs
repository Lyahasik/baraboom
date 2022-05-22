namespace Baraboom.Effects
{
	public class AdditionalPlantingSlot : TemporaryEffect
	{
		protected override void StartEffect(IPlayer player)
		{
			player.AddPlantingSlot();
		}

		protected override void StopEffect(IPlayer player)
		{
			player.RemovePlantingSlot();
		}
	}
}