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
		protected abstract void SaveState();

		#endregion

		#region interior

		protected bool _state;

		void OnClick()
		{
			_state = !_state;

			SaveState();
			Animate(_state);
		}

		#endregion
	}
}