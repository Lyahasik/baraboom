using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.MainMenu.UI
{
	public class ActionToggleMusic : ButtonAction
	{
		protected override void OnClick()
		{
			_playerPreferences.Music = !_playerPreferences.Music;
		}

		[Inject] private PlayerPreferences _playerPreferences;
	}
}