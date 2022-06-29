using UnityEngine;

namespace Baraboom.MainMenu.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class Page : MonoBehaviour
	{
		#region facade

		public string ID => _id;

		#endregion

		#region interior

		[SerializeField] private string _id;

		private CanvasGroup _canvasGroup;

		private void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}

		#endregion
	}
}