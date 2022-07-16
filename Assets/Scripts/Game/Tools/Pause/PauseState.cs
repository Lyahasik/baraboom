using UnityEngine;

namespace Baraboom.Game
{
	public class PauseState : MonoBehaviour
	{
		#region facade

		public bool Paused
		{
			get => _paused;
			set
			{
				_paused = value;
				Time.timeScale = _paused ? 0f : 1f;
			}
		}

		#endregion

		#region interior

		private bool _paused;

		#endregion
	}
}