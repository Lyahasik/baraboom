using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Baraboom.LevelMenu.UI
{
	public class Level : MonoBehaviour
	{
		[SerializeField] private string _title;
		[SerializeField] private string _scene;
		[SerializeField] private Sprite _sprite;

		private void Awake()
		{
			GetComponentInChildren<Image>().sprite = _sprite;
			GetComponentInChildren<TMP_Text>().text = _title;
			GetComponentInChildren<StartLevelAction>().LevelScene = _scene;
		}
	}
}