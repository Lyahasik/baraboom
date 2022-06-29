using Baraboom.Core.UI;
using Zenject;

namespace Baraboom.MainMenu.UI
{
	public class ActionGoToMainPage : ButtonAction
	{
		[Inject] private PageGroup _pageGroup;

		protected override void OnClick()
		{
			_pageGroup.SwitchPage(0);
		}
	}
}