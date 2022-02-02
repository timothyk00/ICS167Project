using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Kevin
public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public GameObject player;
    
    //How far the enemies sight is
    public float enemyDistanceRun = 4.0f;

    [SerializeField] int health;
    [SerializeField] int attack;

    
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //Run at player
        if (distance < enemyDistanceRun)
        {
            Vector3 facePlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position - facePlayer;
            enemy.SetDestination(newPos);
        }
    }

    private void AttackPlayer()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}