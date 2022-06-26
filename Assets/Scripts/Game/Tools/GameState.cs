using UnityEngine;

namespace Baraboom.Game.Tools
{
	public class GameState : MonoBehaviour
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