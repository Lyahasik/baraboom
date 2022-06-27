using System;

namespace Baraboom.Game.UI.Protocols
{
	public interface IObservablePlayerData
	{
		event Action Changed;

		int Health { get; }

		float Speed { get; }

		int PlantingSlots { get; }

		int ExplosionDamage { get; }

		int ExplosionRange { get; }
	}
}