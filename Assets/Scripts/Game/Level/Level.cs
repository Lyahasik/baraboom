using System;
using System.Collections.Generic;
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

		public void AddBot(GameObject value)
		{
			_listBots.Add(value);
		}

		public void RemoveBot(GameObject value)
		{
			_listBots.Remove(value);
			
			if (_listBots.Count <= 0)
				Invoke(nameof(LevelPassed), PassLevelDelay);
		}

		private void LevelPassed()
		{
			_gameEvents.InvokeVictory();
		}

		#endregion

		#region interior

		private const float PassLevelDelay = 1.05f;
		
		[Inject] private IBlockRegistry _blockRegistry;
		[Inject] private GameEvents _gameEvents;

		private Action _changed;
		private readonly BlockMap _map = new();
		private List<GameObject> _listBots = new();

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