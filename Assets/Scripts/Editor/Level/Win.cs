using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Bots;
using UnityEditor;
using UnityEngine;

namespace Baraboom.Debug
{
	public static class Win
	{
		[MenuItem("Baraboom/Level/Win")]
		public static void Do()
		{
			foreach (var bot in Object.FindObjectsOfType(typeof(BotData)))
				((IBombTarget)bot).TakeDamage(100);
		}
	}
}