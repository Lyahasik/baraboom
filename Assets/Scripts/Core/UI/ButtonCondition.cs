using UnityEngine;
using UnityEngine.UI;

namespace Baraboom.Core.UI
{
	[RequireComponent(typeof(Button))]
	public abstract class ButtonCondition : MonoBehaviour
	{
		#region extension

		protected abstract bool State { get; }

		protected virtual void Awake()
		{
			_button = GetComponent<Button>();
			FetchState();
		}

		protected void FetchState()
		{
			_button.interactable = State;
		}

		#endregion

		#region interior

		private Button _button;

		#endregion
	}
}