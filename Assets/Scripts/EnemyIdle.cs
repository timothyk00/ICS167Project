using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdle : MonoBehaviour
{  
    [SerializeField] float distanceMove;
    [SerializeField] float speed;
    
    public NavMeshAgent enemy;
    public GameObject player;
    public float enemyDistanceRun = 4.0f;

    private Vector3 startingPosition;
    bool inRange = false;

    
    void Start()
    {
        startingPosition = transform.position;
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {   
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance >= enemyDistanceRun)
        {
            Vector3 v = startingPosition;

            v.z += distanceMove * Mathf.Sin(Time.time * speed);
            transform.position= v;
        }
        else
        {
            startingPosition = transform.position;
        }
    }
}
