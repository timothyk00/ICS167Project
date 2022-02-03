using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan

//This scritp immediately destroys the heal aura projectile after its been generated.

public class Healaura : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }  
}
