using UnityEngine;

namespace Baraboom
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayer _player;
        private IBombSpawner _bombSpawner;

        private void Start()
        {
            _player = GetComponent<IPlayer>();

            _bombSpawner = FindObjectOfType<BombSpawner>();
            _bombSpawner.BombExploded += _player.RemovePlantedBomb;
        }

        private void Update()
        {
            ProcessPlanting();
            ProcessMovement();
        }

        private void ProcessPlanting()
        {
            if (!Input.GetKeyDown(KeyCode.Space))
                return;
            if (!_player.HaveBombs)
                return;

            _player.AddPlantedBomb();

            _bombSpawner.DamageMultiplier = _player.DamageMultiplier;
            _bombSpawner.RangeIncrease = _player.RangeIncrease;
            _bombSpawner.SpawnBomb(transform.position);
        }

        private void ProcessMovement()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal, 0, vertical) * _player.Speed * Time.deltaTime; 
        }
    }
}