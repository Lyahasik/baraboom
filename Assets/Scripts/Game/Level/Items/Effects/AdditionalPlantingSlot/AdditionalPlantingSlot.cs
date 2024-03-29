namespace Baraboom.Game.Level.Items
{
	public class AdditionalPlantingSlot : Effect<IAdditionalPlantingSlotRecipient>
	{
		protected override void Apply(IAdditionalPlantingSlotRecipient recipient)
		{
			recipient.AddPlantingSlot();
		}
	}
}