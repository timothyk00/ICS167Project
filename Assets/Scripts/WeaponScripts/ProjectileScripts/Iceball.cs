using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
//This script handles the ice element projectile behaviour.
public class Iceball : MonoBehaviour
{
    private float fbSpeed = 10.0f;
    private float duration = 2.0f; 
    private float lifeTimer;
    public bool freeze = true; //To later be used to add effects to enemies when they collide with this particle.
    void Start()
    {
        lifeTimer = duration; //Each projectile starts with a lifetimer that depletes each second
    }

    void Update()
    {
       transform.position += transform.forward*fbSpeed*Time.deltaTime;
       lifeTimer-=Time.deltaTime;
      if (lifeTimer <=0f)
      {
        Destroy(gameObject); //Destroyed when lifetimer is gone
      }

    }
    void OnCollisionEnter(Collision other)
    {   //must only collide with objects with these tags.
        if (other.gameObject.tag == "block" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player" || other.gameObject.tag == "wall")
        {   
            Destroy(gameObject);
        }


    }
}
