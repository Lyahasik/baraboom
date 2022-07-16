using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.MainMenu.UI
{
	public class ActionToggleSound : ButtonAction
	{
		protected override void OnClick()
		{
			_playerPreferences.Sound = !_playerPreferences.Sound;
		}

		[Inject] private PlayerPreferences _playerPreferences;
	}
}