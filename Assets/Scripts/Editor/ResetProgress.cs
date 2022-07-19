using UnityEditor;
using UnityEngine;

namespace Baraboom.Debug
{
	public static class ResetProgress
	{
		[MenuItem("Baraboom/Reset progress")]
		public static void Do()
		{
			PlayerPrefs.SetInt("levels_completed", 0);
		}
	}
}