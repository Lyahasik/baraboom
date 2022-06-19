using System;
using System.Collections.Generic;

namespace Baraboom.Game.Level.Environment
{
	public interface IBlockRegistry : IEnumerable<Block>
	{
		event Action<Block> BlockAdded;

		event Action<Block> BlockRemoved;

		void Register(Block block);
	}
}