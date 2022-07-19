using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Baraboom.Game.Data;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ConditionHasNextLevel : ButtonCondition
	{
		#region extension

		protected override bool State
		{
			get
			{
				return _levelData.Index < _gameData.LevelCount - 1 &&
				       _levelData.Index < _persistentPlayerData.LevelsCompleted;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_gameEvents.Victory += OnVictory;
		}

		#endregion

		#region interior

		[Inject] private GameData _gameData;
		[Inject] private PersistentPlayerData _persistentPlayerData;
		[Inject] private LevelData _levelData;
		[Inject] private GameEvents _gameEvents;

		private void OnDestroy()
		{
			_gameEvents.Victory -= OnVictory;
		}

		private void OnVictory()
		{
			FetchState();
		}

		#endregion
	}
}