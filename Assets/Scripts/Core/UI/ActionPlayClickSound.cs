using Zenject;

namespace Baraboom.Core.UI
{
	public class ActionPlayClickSound : ButtonAction
	{
		#region extension

		protected override void OnClick()
		{
			_audioPlayer.PlayClickSound();
		}

		#endregion

		#region interior

		[Inject] private UIAudioPlayer _audioPlayer;

		#endregion
	}
}