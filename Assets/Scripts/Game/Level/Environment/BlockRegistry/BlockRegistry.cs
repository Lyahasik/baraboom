using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logger = Baraboom.Game.Tools.Logging.Logger;

namespace Baraboom.Game.Level.Environment
{
	public sealed class BlockRegistry : MonoBehaviour, IBlockRegistry
	{
		#region facade

		event Action<Block> IBlockRegistry.BlockAdded
		{
			add => _blockAdded += value;
			remove => _blockAdded -= value;
		}

		event Action<Block> IBlockRegistry.BlockRemoved
		{
			add => _blockRemoved += value;
			remove => _blockRemoved -= value;
		}

		void IBlockRegistry.Register(Block block)
		{
			_blockAdded?.Invoke(block);
			block.Destroyed += () => _blockRemoved?.Invoke(block);
		}

		IEnumerator<Block> IEnumerable<Block>.GetEnumerator()
		{
			return _blocks.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (this as IEnumerable<Block>).GetEnumerator();
		}

		#endregion

		#region interior

		private Action<Block> _blockAdded;
		private Action<Block> _blockRemoved;
		private readonly HashSet<Block> _blocks = new();

		#endregion
	}
}