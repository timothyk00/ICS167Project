using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Kevin
public class Enemy : MonoBehaviour
{
    public NavMeshAgent _enemy;
    public GameObject _player;
    
    //How far the enemies sight is
    public float _enemyDistanceRun = 4.0f;

    [SerializeField] int _health;
    [SerializeField] int _attack;

    
    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        //Run at player
        if (distance < _enemyDistanceRun)
        {
            Vector3 facePlayer = transform.position - _player.transform.position;
            Vector3 newPos = transform.position - facePlayer;
            _enemy.SetDestination(newPos);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}