using UnityEngine;

namespace Baraboom.Core.Tools.Extensions
{
	public static class ExtensionColor
	{
		public static Color WithA(this Color @this, float a)
		{
			return new Color(@this.r, @this.g, @this.b, a);
		}
	}
}