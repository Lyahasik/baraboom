using UnityEngine;

[CreateAssetMenu(fileName = "SODataCharacter", menuName = "Scriptable Objects/Player/Data Character", order = 1)]
public class SODataCharacter : ScriptableObject
{
    private const float SPEED_FACTOR = 0.01f;
    
    [SerializeField] private float _speed;

    public float Speed => _speed * SPEED_FACTOR;
}
