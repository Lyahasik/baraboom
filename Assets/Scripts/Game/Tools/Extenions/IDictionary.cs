using System;
using System.Collections.Generic;

namespace Baraboom.Game.Tools.Extensions
{
	public static class IDictionary
	{
		public static TValue GetOrInit<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key) where TValue : new()
		{
			if (@this.TryGetValue(key, out var value))
				return value;

			return @this[key] = new TValue();
		}

		public static TValue GetOrInit<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, Func<TValue> valueInitializer)
		{
			if (@this.TryGetValue(key, out var value))
				return value;

			return @this[key] = valueInitializer();
		}

		public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key) where TValue : class
		{
			return @this.TryGetValue(key, out var value) ? value : null;
		}
	}
}