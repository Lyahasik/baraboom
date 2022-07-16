using Baraboom.Core.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Baraboom.LevelMenu.UI
{
	[RequireComponent(typeof(CanvasGroup))]
	public class Level : MonoBehaviour
	{
		[SerializeField] private int _id;
		[SerializeField] private Sprite _sprite;

		[Inject] private PlayerData _playerData;

		private void Awake()
		{
			GetComponentInChildren<Image>().sprite = _sprite;
			GetComponentInChildren<TMP_Text>().text = $"LEVEL {_id}";
			GetComponentInChildren<ActionPlayLevel>().LevelScene = $"Level{_id}";

			if (_playerData.LevelsCompleted + 1 < _id)
			{
				var canvasGroup = GetComponent<CanvasGroup>();

				canvasGroup.alpha = 0.5f;
				canvasGroup.interactable = false;
			}
		}
	}
}