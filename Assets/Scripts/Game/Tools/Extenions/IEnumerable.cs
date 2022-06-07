using System.Collections.Generic;

namespace Baraboom.Game.Tools.Extensions
{
	public static class IEnumerable
	{
		public static IEnumerable<(T, int)> Enumerate<T>(this IEnumerable<T> @this)
		{
			using var enumerator = @this.GetEnumerator();

			var index = 0;
			while (enumerator.MoveNext())
				yield return (enumerator.Current, index++);
		}
	}
}