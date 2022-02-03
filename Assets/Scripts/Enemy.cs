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
        _player = GameObject.Find("Player"); //currently finds the player, but will be changed to find any object with Player tag

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        //Run at player if in sight
        if (distance < _enemyDistanceRun)
        {
            //chase
            Vector3 facePlayer = transform.position - _player.transform.position;
            Vector3 newPos = transform.position - facePlayer;
            _enemy.SetDestination(newPos);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile" || collision.gameObject.tag == "bolt")
        {
            _health-=10;
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}