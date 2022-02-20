using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElementFactory;
//Cleon Doan
//This script creates an abilityFactory that returns the correct element 
// to the player's weapons

public class ElementPickup : MonoBehaviour
{
    private string elementType;
    private bool canPickup = false;
    private float pickUpTimer = 100.0f;
    private float duration;
    private GameObject powerUp;
    private string pickUpButton;
    private List<Ability> cs;
    private PlayerWeaponController playerWC;

    // Retrieves the player script of weapon controller to change variables and call its UI update function
    AbilityFactory myFactory = new AbilityFactory(); //create a new abilit/Element Factory

    void Start()
    {
        pickUpButton = "pickUp" + this.GetComponent<PlayerMovementController>()._playerNum;
        playerWC = this.GetComponent<PlayerWeaponController>();
        cs = playerWC.weapons;
    }

    void Update()
    {
        if (canPickup && Input.GetButtonDown(pickUpButton))
        {
            Debug.Log("working");
            if (cs.Count == 2)
            {
                cs = new List<Ability>() { cs[0], myFactory.GetAbility(elementType) }; //Updates the players list of weaponries with the given ability from the factory.
                playerWC.UpdateWeapons(); //Updates the UI
            }
            else
            {
                if (cs.IndexOf(myFactory.GetAbility(elementType)) == -1)
                    cs.Add(myFactory.GetAbility(elementType));
                playerWC.UpdateWeapons();
            }
            Destroy(powerUp);
        }
        Debug.Log(duration);
        if (duration != 0)
        {
            duration -= 1;
        }
        if (duration <= 0)
        {
            canPickup = false;
            duration = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Powerup") //If colliding with any tag with Player
        {
            elementType = collision.gameObject.GetComponent<ElementTyping>().elementType;
            Debug.Log(elementType);
            canPickup = true;
            duration = pickUpTimer;
            powerUp = collision.gameObject;
        }
    }
}
