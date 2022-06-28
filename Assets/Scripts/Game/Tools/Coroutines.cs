using System;
using System.Collections;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	public static class Coroutines
	{
		private const float DefaultAnimationDuration = 0.25f;

		public static IEnumerator MoveToColumn(DiscreteTransform discreteTransform, Vector2Int column, float duration)
		{
			var targetPosition = column.WithZ(discreteTransform.DiscretePosition.z);

			yield return Move(
				discreteTransform.transform,
				DiscreteTranslator.ToContinuous(targetPosition),
				duration
			);
		}

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
				DefaultAnimationDuration
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
				DefaultAnimationDuration
			);
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
	}
}