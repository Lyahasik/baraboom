using Baraboom.Core.Data;
using UnityEngine;
using Zenject;

namespace Baraboom.Tools.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPlayer : MonoBehaviour
    {
        private void Start()
        {
            if (_playerPreferences.Sound)
                GetComponent<AudioSource>().Play();
        }

        [Inject] private PlayerPreferences _playerPreferences;
    }
}
