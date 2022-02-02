using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healaura : MonoBehaviour
{
    void Start()
    {
    //player.GetComponent<PlayerHealthSystem>;
    }
    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }  
}
