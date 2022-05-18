using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        ManagerBlocksCensus.AddBlock(gameObject);
    }
}
