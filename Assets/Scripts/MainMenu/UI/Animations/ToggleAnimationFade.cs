using Baraboom.Core.Tools;
using Baraboom.Core.Tools.Extensions;
using Baraboom.Core.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace Baraboom.MainMenu.UI
{
	[RequireComponent(typeof(Image))]
	public class ToggleAnimationFade : ToggleAnimation
	{
		#region extension

		protected override void Awake()
		{
			base.Awake();
			_image = GetComponent<Image>();
		}

		protected override void Animate(bool targetState)
		{
			var alphaStart = _image.color.a;
			var alphaFinish = targetState ? 1f : 0.35f;

			StartCoroutine(
				Coroutines.Update(
					phase => _image.color = _image.color.WithA(Mathf.Lerp(alphaStart, alphaFinish, Easing.InOutCubic(phase))),
					UIConstants.ShortenedAnimationDuration
				)
			);
		}

		#endregion

		#region interior

		private Image _image;

		#endregion
	}
}