using System.Collections;
using System.Collections.Generic;
using Baraboom.Game.Tools.DiscreteWorld;
using JetBrains.Annotations;
using UnityEngine;

namespace Baraboom.Game.Tools
{
	[RequireComponent(typeof(DiscreteCollider))]
	public abstract class Killer<TTarget> : MonoBehaviour where TTarget : ITarget
	{
		#region extension

		protected int _damage;
		protected float _ignoreTargetDuration;

		#endregion

		#region interior

		private readonly HashSet<TTarget> _ignoredTargets = new();

		[UsedImplicitly]
		private void OnDiscreteCollision(DiscreteCollider other)
		{
			var target = other.GetComponent<TTarget>();
			if (target == null)
				return;

			if (_ignoredTargets.Contains(target))
				return;

			Debug.Log(gameObject.name + ":" + _ignoreTargetDuration);
			target.TakeDamage(_damage);
			StartCoroutine(IgnoreTarget(target));
		}

		private IEnumerator IgnoreTarget(TTarget target)
		{
			_ignoredTargets.Add(target);

			yield return new WaitForSeconds(_ignoreTargetDuration);

			_ignoredTargets.Remove(target);
		}

		#endregion
	}
}