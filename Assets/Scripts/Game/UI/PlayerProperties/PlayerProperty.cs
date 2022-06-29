using Baraboom.Game.UI.Protocols;
using TMPro;
using UnityEngine;
using Zenject;
using Logger = Baraboom.Core.Tools.Logging.Logger;

namespace Baraboom.Game.UI
{
	public abstract class PlayerProperty : MonoBehaviour
	{
		#region extension

		protected abstract int GetCount(IObservablePlayerData data);

		#endregion

		#region interior

		[Inject] private IObservablePlayerData _playerData;

		private Logger _logger;
		private TMP_Text _countText;

		private void Awake()
		{
			_logger = Logger.For<PlayerProperty>();

			_countText = GetComponentInChildren<TMP_Text>();
			if (_countText == null)
				_logger.LogError("Count element not found!");

			_playerData.Changed += OnPlayerDataChanged;
		}

		private void Start()
		{
			FetchCount();
		}

		private void OnDestroy()
		{
			_playerData.Changed -= OnPlayerDataChanged;
		}

		private void FetchCount()
		{
			_countText.text = GetCount(_playerData).ToString();
		}

		private void OnPlayerDataChanged()
		{
			FetchCount();
		}

		#endregion
	}
}