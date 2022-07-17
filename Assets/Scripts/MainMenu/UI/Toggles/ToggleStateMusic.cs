using Baraboom.Core.Data;
using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.MainMenu.UI
{
	public class ToggleStateMusic : ToggleState
	{
		#region extension

		protected override bool PersistentState
		{
			get => _playerPreferences.Music;
			set => _playerPreferences.Music = value;
		}

		#endregion

		#region interior

		[Inject] private PlayerPreferences _playerPreferences;

		#endregion
	}
}