namespace Baraboom
{
	public interface IPlayer : IDamageable
	{
		public float Speed { get; }
		public float DamageMultiplier { get; }
		public int RangeIncrease { get; }
		public bool HaveBombs { get; }

		public void Heal(float amount);

		public void BoostSpeed(float multiplier);
		public void ResetSpeed();

		public void BoostDamage(float multiplier);
		public void ResetDamage();

		public void BoostRange(int increase);
		public void ResetRange();

		public void AddPlantingSlot();
		public void RemovePlantingSlot();
		
		public void AddPlantedBomb();
		public void RemovePlantedBomb();
	}
}