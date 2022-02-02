using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthblock : MonoBehaviour
{
    private float duration = 3.0f; 
    private float lifeTimer;
    void Start()
    {
        lifeTimer = duration;
    }

    // Update is called once per frame
    void Update()
    {
    lifeTimer-= Time.deltaTime;
        if (lifeTimer <=0f)
          {
            Destroy(gameObject);
          } 
    }
    public void OnTriggerEnter(Collider other)
    {
    if (other.tag == "projectile")
    {   
        Destroy(gameObject);
    }
    }
}
