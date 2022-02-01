using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{  
    [SerializeField] float distanceMove;
    [SerializeField] float speed;

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
       Vector3 v = startingPosition;

       v.z += distanceMove * Mathf.Sin(Time.time * speed);
       transform.position= v;
    }
}
