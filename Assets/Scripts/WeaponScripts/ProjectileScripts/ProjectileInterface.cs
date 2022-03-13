using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
public class ProjectileInterface : MonoBehaviour
{
    private float lifeTimer;
    private ElementTyping scriptCheck;
    private string elementType;
    private float pSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
       scriptCheck = this.GetComponent<ElementTyping>();
       if (scriptCheck != null)
       {
            elementType = scriptCheck.elementType;
           switch (elementType){
           case "earth":
                lifeTimer = 3.0f;
                break;
            case "electric":
                lifeTimer = 1.0f;
                break;
            case "fire":
                lifeTimer = 1.0f;
                pSpeed = 2f;
                break;
            case "ice":
                lifeTimer = 2f;
                pSpeed = 20.0f;
                break;
                }
       }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer-=Time.deltaTime;
        if (lifeTimer<=0f)
        {
            Destroy(gameObject);
        }
        if (pSpeed != 0){
            transform.position+=transform.forward*pSpeed*Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
    if ((other.gameObject.tag == "projectile" && elementType == "earth") || (other.gameObject.tag =="block" && elementType != "fire") || elementType == "heal")
    {
        Destroy(gameObject);
    }

    if (elementType == "ice" && (other.gameObject.tag == "Enemy" || other.gameObject.tag=="Player"||other.gameObject.tag=="wall"))
        Destroy(gameObject);
    }
}
