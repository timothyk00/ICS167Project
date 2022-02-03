using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
//This script handles the electric element projectile behaviour.
public class Electricbolt : MonoBehaviour
{
    private float duration = 1.0f; 
    private float lifeTimer;
    void Start()
    {
        lifeTimer = duration;  //Each projectile starts with a lifetimer that depletes each second
    }

    void Update()
    {
       lifeTimer-=Time.deltaTime;
      if (lifeTimer <=0f)
      {
        Destroy(gameObject);  //Destroyed when lifetimer is gone
      }

    }
}
