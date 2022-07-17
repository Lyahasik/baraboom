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
		[SerializeField] private Sprite _screenshot;
		[SerializeField] private Image _screenshotImage;
		[SerializeField] private TMP_Text _levelName;
		[SerializeField] private ActionPlayLevel _playerLevelAction;

		[Inject] private PlayerData _playerData;

		private void Awake()
		{
			_screenshotImage.sprite = _screenshot;
			_levelName.text = $"LEVEL {_id}";
			_playerLevelAction.LevelScene = $"Level{_id}";

			if (_playerData.LevelsCompleted + 1 < _id)
			{
				var canvasGroup = GetComponent<CanvasGroup>();

				canvasGroup.alpha = 0.5f;
				canvasGroup.interactable = false;
			}
		}
	}
}