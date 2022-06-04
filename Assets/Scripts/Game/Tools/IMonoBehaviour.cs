using UnityEngine;

namespace Baraboom.Game.Tools
{
	public interface IMonoBehaviour
	{
	}
	
	public static class ExtensionIMonoBehaviour
	{
		public static MonoBehaviour ToMonoBehaviour(this IMonoBehaviour @this)
		{
			return @this as MonoBehaviour;
		}
	}
}