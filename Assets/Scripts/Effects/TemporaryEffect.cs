using System.Collections;
using Baraboom;
using UnityEngine;

namespace Baraboom.Effects
{
	public abstract class TemporaryEffect : MonoBehaviour, IEffect
	{
		[SerializeField] private float _duration;
		
		public IEnumerator Apply(IPlayer player)
		{
			StartEffect(player);

			yield return new WaitForSeconds(_duration);

			if (player != null)
				StopEffect(player);
		}

		protected abstract void StartEffect(IPlayer player);
		protected abstract void StopEffect(IPlayer player);
	}
}