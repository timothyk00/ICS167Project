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
        public void OnTriggerEnter(Collider other)
    {   //must only collide with objects with these tags.
        if (other.tag == "block" || other.tag == "Enemy" || other.tag == "Player")
        {   
            Destroy(gameObject);
        }


    }
}
