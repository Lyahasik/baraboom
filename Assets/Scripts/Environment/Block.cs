using UnityEngine;

namespace Environment
{
    public class Block : MonoBehaviour
    {
        private void Start()
        {
            ManagerBlocksCensus.AddBlock(gameObject);
        }
    }
}
