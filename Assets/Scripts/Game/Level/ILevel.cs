using System;

namespace Baraboom.Game.Level
{
	public interface ILevel
	{
		event Action Changed;

		public ReadOnlyBlockMap BlockMap { get; }
	}
}