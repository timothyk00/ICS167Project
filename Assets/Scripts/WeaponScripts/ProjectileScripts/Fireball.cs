using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
//This script handles the fire element projectile behaviour.
public class Fireball : MonoBehaviour
{
    private float fbSpeed = 0.2f;
    private float duration = 1.0f; 
    private float lifeTimer;
    public bool burn = true; //To later be used to add effects to enemies when they collide with this particle.
    void Start()
    {
        lifeTimer = duration;  //Each projectile starts with a lifetimer that depletes each second
    }

    void Update()
    {
        transform.position += transform.forward * fbSpeed * Time.deltaTime;
        lifeTimer -= Time.deltaTime;
      if (lifeTimer <=0f)
      {
        Destroy(gameObject);  //Destroyed when lifetimer is gone
      }

    }
}
