using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour
{
    private Transform _player;
    private float _damage = 1;
    private EnemyHealth _enemyHealth;
    private PlayerHealth _playerHealth;

    [Inject]
    private void Construct(PlayerController playerController, PlayerHealth playerHealth)
    {
        _player = playerController.gameObject.transform;
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        bool isPlayerAlive = _player == null ? false : true;
        Debug.Log("Is player alive: " + isPlayerAlive);
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.ApplyDamage(_damage);
            _enemyHealth.ApplyDamage(_playerHealth.Damage);
        }
    }
}