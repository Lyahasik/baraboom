using Baraboom.Core.Data;
using UnityEngine;
using Zenject;

namespace Baraboom.Core.UI
{
	[RequireComponent(typeof(AudioSource))]
	public class UIAudioPlayer : MonoBehaviour
	{
		#region facade

		public void PlayClickSound()
		{
			PlaySound(_clickClip);
		}

		#endregion

		#region interior

		[SerializeField] private AudioClip _clickClip;

		[Inject] private PlayerPreferences _playerPreferences;

		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void PlaySound(AudioClip clip)
		{
			if (!_playerPreferences.Sound)
				return;

			_audioSource.clip = clip;
			_audioSource.Play();
		}

		#endregion
	}
}