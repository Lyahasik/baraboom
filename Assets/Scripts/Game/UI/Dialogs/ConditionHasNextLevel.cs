using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Baraboom.Game.Data;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ConditionHasNextLevel : ButtonCondition
	{
		#region extension

		protected override bool State => _levelData.Index != _gameData.LevelCount - 1;

		#endregion

		#region interior

		[Inject] private GameData _gameData;
		[Inject] private LevelData _levelData;

		#endregion
	}
}