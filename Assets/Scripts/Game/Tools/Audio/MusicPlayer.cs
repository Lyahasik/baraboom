using Baraboom.Core.Data;
using UnityEngine;
using Zenject;

namespace Baraboom.Tools.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        private void Start()
        {
            if (_playerPreferences.Music)
                GetComponent<AudioSource>().Play();
        }

        [Inject] private PlayerPreferences _playerPreferences;
    }
}
