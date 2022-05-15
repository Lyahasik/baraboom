using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DataPlayer))]
public class PlayerControl : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private DataPlayer _dataPlayer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _dataPlayer = GetComponent<DataPlayer>();
    }

    private void Update()
    {
        Vector3 directionMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        
        Move(directionMove);
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * _dataPlayer.Speed);
    }
}
