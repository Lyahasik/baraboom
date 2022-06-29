using Baraboom.Core.Tools;
using Baraboom.Core.Tools.Extensions;
using Baraboom.Core.UI;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Baraboom.MainMenu.UI
{
	[RequireComponent(typeof(RectTransform))]
	public class PageGroup : MonoBehaviour
	{
		#region facade

		public void SwitchPage(int index)
		{
			var currentOffset = Offset;
			var targetOffset = -1 * index * PageWidth;

			StartCoroutine(
				Coroutines.Update(
					phase => Offset = Mathf.Lerp(currentOffset, targetOffset, Easing.InOutCubic(phase)),
					UIConstants.DefaultAnimationDuration
				)
			);
		}

		#endregion

		#region interior

		private RectTransform _rectTransform;

		private float Offset
		{
			get => _rectTransform.anchoredPosition.x;
			set => _rectTransform.anchoredPosition = _rectTransform.anchoredPosition.WithX(value);
		}

		private float PageWidth => UIConstants.ReferenceResolution.X;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		#endregion
	}
}