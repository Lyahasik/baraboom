using Baraboom.Core.UI;
using UnityEngine;

namespace Baraboom.MainMenu.UI
{
	public class ActionToggleSound : ButtonAction
	{
		protected override void OnClick()
		{
			int newValue = PlayerPrefs.GetInt("OnSound") == 1 ? 0 : 1;
			PlayerPrefs.SetInt("OnSound", newValue);
		}
	}
}