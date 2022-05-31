namespace Baraboom.Effects
{
	public class AdditionalPlantingSlot : Effect<IAdditionalPlantingSlotRecipient>
	{
		protected override void Apply(IAdditionalPlantingSlotRecipient recipient)
		{
			recipient.AddPlantingSlot();
		}
	}
}