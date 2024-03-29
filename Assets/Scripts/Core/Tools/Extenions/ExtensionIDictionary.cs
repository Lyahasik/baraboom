using System.Collections.Generic;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionIDictionary
	{
		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key) where TValue : class
		{
			return @this.TryGetValue(key, out var value) ? value : null;
		}
	}
}