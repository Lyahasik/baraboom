using System;
using UnityEngine;

namespace Baraboom.Core.Tools
{
	public class VerboseBehaviour : MonoBehaviour
	{
		public event Action Destroyed;

		protected virtual void OnDestroy()
		{
			Destroyed?.Invoke();
		}
	}
}