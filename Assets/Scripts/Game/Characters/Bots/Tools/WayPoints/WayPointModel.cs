using UnityEngine;

namespace Baraboom.Game.Characters.Bots.Tools
{
	public class WayPointModel : MonoBehaviour
	{
		private void Awake()
		{
			if (!Application.isEditor)
				gameObject.SetActive(false);
		}
	}
}