using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script handles the fire element projectile behaviour.
public class Fireball : MonoBehaviour
{
    private float fbSpeed = 10.0f;
    private float duration = 2.0f; 
    private float lifeTimer;
    void Start()
    {
        lifeTimer = duration;
    }

    void Update()
    {
       transform.position += transform.forward*fbSpeed*Time.deltaTime;
       lifeTimer-=Time.deltaTime;
      if (lifeTimer <=0f)
      {
        Destroy(gameObject);
      }

    }
}
