using UnityEngine;

namespace Baraboom.Game.Tools
{
	public class ManualTimer
	{
		private readonly float _expirationTime;

		public bool IsRunning
		{
			get => Time.time < _expirationTime;
		}

		public ManualTimer(float duration)
		{
			_expirationTime = Time.time + duration;
		}
	}
}