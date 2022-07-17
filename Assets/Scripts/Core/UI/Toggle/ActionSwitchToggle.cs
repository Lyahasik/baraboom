using UnityEngine;

namespace Baraboom.Core.UI
{
	[RequireComponent(typeof(ToggleState))]
	public class ActionSwitchToggle : ButtonAction
	{
		#region extension

		protected override void Awake()
		{
			base.Awake();
			_toggleState = GetComponent<ToggleState>();
		}

		protected override void OnClick()
		{
			_toggleState.State = !_toggleState.State;
		}

		#endregion

		#region interior

		private ToggleState _toggleState;

		#endregion
	}
}