using UnityEngine;
using UnityEngine.UI;

namespace Baraboom.Game.UI
{
	[RequireComponent(typeof(Button))]
	public abstract class ButtonAction : MonoBehaviour
	{
		protected virtual void Awake()
		{
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		protected abstract void OnClick();
	}
}