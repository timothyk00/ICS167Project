using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

//Kevin Luu + Timothy Kwon
public class Enemy : MonoBehaviour
{
    public NavMeshAgent _enemy;
    public GameObject _player;
    
    //How far the enemies sight is
    public float _enemyDistanceRun = 4.0f;

    public int _health = 10;
    public int _attack = 5;

    public Slider _healthSlider;
    
    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player"); //currently finds the player, but will be changed to find any object with Player tag

        _healthSlider.maxValue = _health;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
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
            _healthSlider.value = _health;

        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}