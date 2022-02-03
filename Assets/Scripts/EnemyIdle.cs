using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Kevin
public class EnemyIdle : MonoBehaviour
{  
    public NavMeshAgent _enemy;
    public GameObject _player;
    
    public float _enemyDistanceRun = 4.0f;

    [SerializeField] float _distanceMove;
    [SerializeField] float _speed;
    
    float _temp;

    private Vector3 _startingPosition;

    void Start()
    {
        _startingPosition = transform.position;
        _enemy = GetComponent<NavMeshAgent>();
        _temp = _speed;
    }

    void Update()
    {   
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance >= _enemyDistanceRun)
        {
            
            Vector3 v = _startingPosition;
            _speed = _temp;
            v.z += _distanceMove * Mathf.Sin(Time.time * _speed);
            transform.position = v;
        }
        else
        {
            Stop();
        }
    }

    void Stop()
    {
        _startingPosition = transform.position;
        _speed = 0;
    }
}
