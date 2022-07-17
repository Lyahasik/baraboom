using System;
using UnityEngine;

namespace Baraboom.Core.UI
{
	public class ToggleState : MonoBehaviour
	{
		#region facade

		public bool State
		{
			get
			{
				return _state;
			}

			set
			{
				_state = value;

				PersistentState = _state;
				StateChanged?.Invoke(_state);
			}
		}

		public event Action<bool> StateChanged;

		#endregion

		#region extension

		protected virtual bool PersistentState
		{
			get => true;
			set {}
		}

		#endregion

		#region interior

		private bool _state;

		private void Awake()
		{
			_state = PersistentState;
		}

		private void Start()
		{
			StateChanged?.Invoke(_state);
		}

		#endregion
	}
}