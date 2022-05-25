namespace Baraboom
{
	public interface IControllablePlayer
	{
		public float DamageMultiplier { get; }
		public int RangeIncrease { get; }
		public bool HaveBombs { get; }

		
		public void AddPlantedBomb();
		public void RemovePlantedBomb();
	}
}