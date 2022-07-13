using UnityEngine;

namespace Baraboom
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySound : MonoBehaviour
    {
        void Start()
        {
            if (PlayerPrefs.GetInt("OnSound", 1) == 1)
                GetComponent<AudioSource>().Play();
        }
    }
}
