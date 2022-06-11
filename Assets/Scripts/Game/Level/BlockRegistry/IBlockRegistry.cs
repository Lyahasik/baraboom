using System;
using System.Collections.Generic;

namespace Baraboom.Game.Level
{
	public interface IBlockRegistry : IEnumerable<Block>
	{
		event Action<Block> BlockAdded;
		
		event Action<Block> BlockRemoved;

		void Register(Block block);
	}
}