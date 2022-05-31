namespace Baraboom
{
	public interface IControllablePlayer
	{
		public int ExplosionDamage { get; }
		public int ExplosionRange { get; }
		public float Speed { get; }
		public bool HaveBombs { get; }

		
		public void AddPlantedBomb();
		public void RemovePlantedBomb();
	}
}