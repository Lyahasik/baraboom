using System;
using Baraboom.Game.Level.Environment;
using UnityEngine;
using Zenject;

namespace Baraboom.Game.Level
{
	public class Level : MonoBehaviour, ILevel
	{
		#region facade

		event Action ILevel.Changed
		{
			add => _changed += value;
			remove => _changed -= value;
		}

		ReadOnlyBlockMap ILevel.BlockMap
		{
			get => _map.AsReadOnly();
		}

		#endregion

		#region interior

		[Inject] private IBlockRegistry _blockRegistry;

		private Action _changed;
		private readonly BlockMap _map = new();

		private void Awake()
		{
			_blockRegistry.BlockAdded += OnBlockAdded;
			_blockRegistry.BlockRemoved += OnBlockRemoved;

			foreach (var block in _blockRegistry)
				_map.AddBlock(block);
		}

		private void OnDestroy()
		{
			_blockRegistry.BlockAdded -= OnBlockAdded;
			_blockRegistry.BlockRemoved -= OnBlockRemoved;
		}

		private void OnBlockAdded(Block block)
		{
			_map.AddBlock(block);
			_changed?.Invoke();
		}

		private void OnBlockRemoved(Block block)
		{
			_map.RemoveBlock(block);
			_changed?.Invoke();
		}

		#endregion
	}
}