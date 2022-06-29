using UnityEngine;
using UnityEngine.UI;

namespace Baraboom.Core.UI
{
	[RequireComponent(typeof(Button))]
	public abstract class ToggleAnimation : MonoBehaviour
	{
		#region extension

		protected virtual void Awake()
		{
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		protected abstract void Animate(bool targetState);

		#endregion

		#region interior

		private bool _state = true;

		void OnClick()
		{
			_state = !_state;
			Animate(_state);
		}

		#endregion
	}
}