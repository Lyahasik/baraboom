using System.Collections;
using Baraboom;
using UnityEngine;

namespace Baraboom.Effects
{
	public class Heal : MonoBehaviour, IEffect
	{
		[SerializeField] private float _amount;

		public IEnumerator Apply(IPlayer player)
		{
			player.Heal(_amount);
			yield break;
		}
	}
}