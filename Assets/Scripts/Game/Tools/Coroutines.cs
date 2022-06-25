using System.Collections;
using Baraboom.Game.Tools.DiscreteWorld;
using Baraboom.Game.Tools.Extensions;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	public static class Coroutines
	{
		public delegate bool UpdateActionDelegate(float phase);

		public static IEnumerator MoveToColumn(DiscreteTransform discreteTransform, Vector2Int column, float duration)
		{
			var targetPosition = column.WithZ(discreteTransform.DiscretePosition.z);

			yield return Coroutines.Move(
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
					if (transform == null)
						return false;

					transform.position = Vector3.Lerp(start, target, phase);
					return true;
				},
				duration
			);

			if (transform != null)
				transform.position = target;
		}

		public static IEnumerator Update(UpdateActionDelegate action, float duration)
		{
			var startTime = Time.time;
			var finishTime = startTime + duration;

			for (var currentTime = startTime; currentTime < finishTime; currentTime = Time.time)
			{
				if (!action((currentTime - startTime) / duration))
					yield break;

				yield return null;
			}
		}
	}
}