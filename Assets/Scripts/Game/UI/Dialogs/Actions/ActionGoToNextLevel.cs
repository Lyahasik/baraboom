using Baraboom.Core.Data;
using Baraboom.Core.UI;
using UnityEngine.SceneManagement;
using Zenject;

namespace Baraboom.Game.UI
{
	public class ActionGoToNextLevel : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			SceneManager.LoadScene($"Level {_playerData.LevelsCompleted}");
		}

		#endregion

		#region interior

		[Inject] private PlayerData _playerData;

		#endregion
	}
}