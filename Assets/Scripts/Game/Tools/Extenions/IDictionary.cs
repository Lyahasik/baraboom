using System.Collections.Generic;

namespace Baraboom.Game.Tools.Extensions
{
	public static class IDictionary
	{
		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key) where TValue : class
		{
			return @this.TryGetValue(key, out var value) ? value : null;
		}
	}
}