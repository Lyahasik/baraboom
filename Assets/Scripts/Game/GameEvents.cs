using System;
using UnityEngine;

namespace Baraboom.Game
{
	public class GameEvents : MonoBehaviour
	{
		#region facade

		public event Action Defeat;

		public event Action Victory;

		public void InvokeDefeat()
		{
			Defeat?.Invoke();
		}

		public void InvokeVictory()
		{
			Victory?.Invoke();
		}

		#endregion
	}
}