using System;
using System.Collections.Generic;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionEnumerable
	{
		public static IEnumerable<T> Flatten<T>(T start, Func<T, T> getNext)
		{
			for (var current = start; current != null; current = getNext(current))
				yield return current;
		}
	}
}