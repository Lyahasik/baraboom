using Baraboom.Core.UI;
using UnityEngine;

namespace Baraboom.MainMenu.UI
{
	public class ActionToggleMusic : ButtonAction
	{
		protected override void OnClick()
		{
			int newValue = PlayerPrefs.GetInt("OnMusic") == 1 ? 0 : 1;
			PlayerPrefs.SetInt("OnMusic", newValue);
		}
	}
}