using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallType : MonoBehaviour
{
  private string elementType;
  public string currentType;
  private ElementTyping scriptCheck;
  void OnCollisionEnter(Collision other)
    {   //must only collide with objects with these tags.
        scriptCheck = other.gameObject.GetComponent<ElementTyping>();
        if (scriptCheck != null)
        {
            elementType = scriptCheck.elementType;
            Debug.Log(elementType );
            if (currentType == elementType)
            {
                Destroy(gameObject);
            }
        }
        }
}
