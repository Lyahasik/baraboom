using Baraboom.Game.Bombs;
using Baraboom.Game.Characters.Player;
using UnityEditor;
using UnityEngine;

namespace Baraboom.Debug
{
	public static class Lose
	{
		[MenuItem("Baraboom/Level/Lose")]
		public static void Do()
		{
			var playerData = Object.FindObjectOfType(typeof(PlayerData));
			var playerAsTarget = (IBombTarget)playerData;

			playerAsTarget.TakeDamage(100);
		}
	}
}