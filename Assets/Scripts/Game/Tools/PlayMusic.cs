using UnityEngine;

namespace Baraboom
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayMusic : MonoBehaviour
    {
        void Start()
        {
            if (PlayerPrefs.GetInt("OnMusic", 1) == 1)
                GetComponent<AudioSource>().Play();
        }
    }
}
