using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int _damage = 1;

    public int Damage
    {
        set
        {
            if (_damage > 1) _damage = value;
        } 
    }
}
