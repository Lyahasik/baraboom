using UnityEngine;
using UnityEngine.UI;

namespace Baraboom.Core.UI
{
	[RequireComponent(typeof(ToggleState))]
	public abstract class ToggleAnimation : MonoBehaviour
	{
		#region extension

		protected virtual void Awake()
		{
			GetComponent<ToggleState>().StateChanged += Animate;
		}

		protected abstract void Animate(bool targetState);

		#endregion
	}
}