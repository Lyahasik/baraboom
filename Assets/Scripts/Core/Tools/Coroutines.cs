using System;
using System.Collections;
using UnityEngine;
using Baraboom.Core.UI;
using UnityEngine.SceneManagement;

namespace Baraboom.Core.Tools
{
	public static class Coroutines
	{
		#region generic

		public static IEnumerator Delay(Action action, float delay)
		{
			yield return new WaitForSeconds(delay);
			action?.Invoke();
		}

		public static IEnumerator Update(Action<float> update, float duration)
		{
			var startTime = Time.time;
			var finishTime = startTime + duration;

			for (var currentTime = startTime; currentTime < finishTime; currentTime = Time.time)
			{
				update((currentTime - startTime) / duration);
				yield return null;
			}

			update(1f);
		}

		public static IEnumerator UpdateUnscaled(Action<float> update, float duration)
		{
			var startTime = Time.unscaledTime;
			var finishTime = startTime + duration;

			for (var currentTime = startTime; currentTime < finishTime; currentTime = Time.unscaledTime)
			{
				update((currentTime - startTime) / duration);
				yield return null;
			}

			update(1f);
		}

		#endregion

		#region scene management

		public static IEnumerator LoadSceneWithDelay(string sceneName, float delay)
		{
			return Delay(() => SceneManager.LoadScene(sceneName), delay);
		}

		#endregion

		#region UI

		public static IEnumerator Show(CanvasGroup group)
		{
			group.interactable = true;
			group.blocksRaycasts = true;

			yield return UpdateUnscaled(
				phase =>
				{
					if (group != null)
						group.alpha = phase;
				},
				UIConstants.DefaultAnimationDuration
			);
		}

		public static IEnumerator Hide(CanvasGroup group)
		{
			group.interactable = false;
			group.blocksRaycasts = false;

			yield return UpdateUnscaled(
				phase =>
				{
					if (group != null)
						group.alpha = 1f - phase;
				},
				UIConstants.DefaultAnimationDuration
			);
		}

		#endregion

		#region movement

		public static IEnumerator Move(Transform transform, Vector3 target, float duration)
		{
			var start = transform.position;

			yield return Update(
				phase =>
				{
					if (transform != null)
						transform.position = Vector3.Lerp(start, target, phase);
				},
				duration
			);

			if (transform != null)
				transform.position = target;
		}

		#endregion
	}
}