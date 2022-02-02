using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Kevin
public class EnemyIdle : MonoBehaviour
{  
    public NavMeshAgent enemy;
    public GameObject player;
    
    public float enemyDistanceRun = 4.0f;

    [SerializeField] float distanceMove;
    [SerializeField] float speed;
    
    float temp;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        enemy = GetComponent<NavMeshAgent>();
        temp = speed;
    }

    void Update()
    {   
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= enemyDistanceRun)
        {
            
            Vector3 v = startingPosition;
            speed = temp;
            v.z += distanceMove * Mathf.Sin(Time.time * speed);
            transform.position= v;
        }
        else
        {
            Stop();
        }
    }

    void Stop()
    {
        startingPosition = transform.position;
        speed = 0;
    }
}
