using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    [SerializeField] private SODataCharacter _dataCharacter;

    public float Speed => _dataCharacter.Speed;
}
