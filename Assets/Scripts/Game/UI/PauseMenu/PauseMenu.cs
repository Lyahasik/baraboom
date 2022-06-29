using Baraboom.Core.Tools;
using UnityEngine;

namespace Baraboom.Game.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class PauseMenu : MonoBehaviour
	{
		#region facade

		public void Show()
		{
			StartCoroutine(Coroutines.Show(_canvasGroup));
		}

		public void Hide()
		{
			StartCoroutine(Coroutines.Hide(_canvasGroup));
		}

		#endregion

		#region interior

		private CanvasGroup _canvasGroup;

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		#endregion
	}
}