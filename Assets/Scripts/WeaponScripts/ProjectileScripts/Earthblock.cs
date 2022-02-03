using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
//This explains the behavior of the earthBlock projectile
public class Earthblock : MonoBehaviour
{
    private float duration = 3.0f;  //The lifetime of the earthblock is longer but every second it will deplete by one. 
    private float lifeTimer;
    void Start()
    {
        lifeTimer = duration; //Each projectile has their own lifetime
    }

    // Update is called once per frame
    void Update()
    {
    lifeTimer-= Time.deltaTime;
        if (lifeTimer <=0f)
          {
            Destroy(gameObject); //Destroy after lifetime has elapsed.
          } 
    }
    void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.tag == "projectile") //Destroy itself when it collides with a projectile
    {   
        Destroy(gameObject);
    }
    }
}
