using System.Collections;
using Baraboom.Core.Tools.Extensions;
using Baraboom.Game.Tools.DiscreteWorld;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	public static class Coroutines
	{
		public static IEnumerator MoveToColumn(DiscreteTransform discreteTransform, Vector2Int column, float duration)
		{
			var targetPosition = column.WithZ(discreteTransform.DiscretePosition.z);

			yield return Core.Tools.Coroutines.Move(
				discreteTransform.transform,
				DiscreteTranslator.ToContinuous(targetPosition),
				duration
			);
		}
	}
}