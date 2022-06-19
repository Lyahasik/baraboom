using System;
using System.Collections.Generic;

namespace Baraboom.Game.Tools.Extensions
{
	public static class ExtensionIEnumerable
	{
		public static IEnumerable<(T, int)> Enumerate<T>(this IEnumerable<T> @this)
		{
			if (@this is null)
				throw new ArgumentNullException();

			using var enumerator = @this.GetEnumerator();

			var index = 0;
			while (enumerator.MoveNext())
				yield return (enumerator.Current, index++);
		}
	}
}