using Events;
using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour, ITakingDamage
    {
        [SerializeField] private SOCharacterData _characterData;

        private int _maxNumberPlantedBombs;
        private int _numberPlantedBombs;

        private int _health;
        private int _damage;
        private int _range;
        private float _speed;
        
        public int Damage => _damage;
        public int Range => _range;
        public float Speed => _speed;

        private void OnEnable()
        {
            ManagerDataPlayer.OnIncrementMaxNumberPlantedBombs += IncrementMaxNumberPlantedBombs;
            ManagerDataPlayer.OnIncrementNumberPlantedBombs += IncrementNumberPlantedBombs;
            ManagerDataPlayer.OnDecrementNumberPlantedBombs += DecrementNumberPlantedBombs;
            
            ManagerDataPlayer.OnAddHealth += AddHealth;
            ManagerDataPlayer.OnIncrementDamage += IncrementDamage;
            ManagerDataPlayer.OnIncrementRange += IncrementRange;
            ManagerDataPlayer.OnAddSpeed += AddSpeed;
        }

        private void Start()
        {
            _maxNumberPlantedBombs = _characterData.MaxNumberPlantedBombs;
            
            _health = _characterData.Health;
            _damage = _characterData.Damage;
            _range = _characterData.Range;
            _speed = _characterData.Speed;
        }

        public void IncrementMaxNumberPlantedBombs()
        {
            _maxNumberPlantedBombs++;
            Debug.Log("max number planted bombs: " + _maxNumberPlantedBombs);
        }

        public void IncrementNumberPlantedBombs()
        {
            _numberPlantedBombs++;
        }

        public void DecrementNumberPlantedBombs()
        {
            _numberPlantedBombs--;
        }

        public bool IsBombsLeft()
        {
            return _numberPlantedBombs < _maxNumberPlantedBombs;
        }

        public void AddHealth(int value)
        {
            _health += value;
            Debug.Log("health: " + _health);
        }

        public void IncrementDamage()
        {
            _damage++;
            Debug.Log("damage: " + _damage);
        }

        public void IncrementRange()
        {
            _range++;
            Debug.Log("range: " + _range);
        }

        public void AddSpeed(float value)
        {
            _speed += value;
            Debug.Log("speed: " + _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            IActivated activated = other.GetComponent<IActivated>();

            if (activated != null)
            {
                activated.Activate();
            }
        }

        public void TakeDamage(int value)
        {
            _health -= value;
            Debug.Log("health: " + _health);
            ManagerDataPlayer.ReduceHealth(value);

            if (_health <= 0)
                Death();
        }

        private void Death()
        {
            Debug.Log("death");
            Destroy(gameObject);
        }
    }
}
