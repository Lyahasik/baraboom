using Baraboom.Core.Tools;
using Baraboom.Core.UI;

namespace Baraboom.LevelMenu.UI
{
	public class ActionPlayLevel : ButtonAction
	{
		#region facade

		public string LevelScene
		{
			set => _levelScene = value;
		}

		#endregion

		#region extension

		protected override void OnClick()
		{
			StartCoroutine(
				Coroutines.LoadSceneWithDelay(
					_levelScene,
					UIConstants.ClickSoundDuration
				)
			);
		}

		#endregion

		#region interior

		private string _levelScene;

		#endregion
	}
}