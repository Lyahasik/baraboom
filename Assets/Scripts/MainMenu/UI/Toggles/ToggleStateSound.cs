using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.MainMenu.UI
{
	public class ToggleStateSound : ToggleState
	{
		#region extension

		protected override bool PersistentState
		{
			get => _playerPreferences.Sound;
			set => _playerPreferences.Sound = value;
		}

		#endregion

		#region interior

		[Inject] private PlayerPreferences _playerPreferences;

		#endregion
	}
}