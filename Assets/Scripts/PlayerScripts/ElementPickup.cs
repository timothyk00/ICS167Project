using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElementFactory;
//Cleon Doan
//This script creates an abilityFactory that returns the correct element 
// to the player's weapons

public class ElementPickup : MonoBehaviour
{
    //holds the current element 
    public string elementType;

    private bool canPickup = false;
    private float pickUpTimer = 100.0f;
    private float duration;
    private GameObject powerUp;
    private string pickUpButton;
    private PlayerWeaponController playerWC;
    private Vector3 currentPos;
    private GameObject interactText;

    AbilityFactory myFactory = new AbilityFactory(); //create a new abilit/Element Factory

     void Start()
    {
        pickUpButton = "pickUp" + this.GetComponent<PlayerMovementController>()._playerNum;
        playerWC = this.GetComponent<PlayerWeaponController>();    
        currentPos = this.transform.position;
        }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, currentPos);
        if (distance <= 5 && canPickup)
        {
            Debug.Log(distance);
            duration = pickUpTimer;
        }
        if (canPickup && Input.GetButtonDown(pickUpButton))
        {
            if (playerWC._weapons.Count == 2)
            {
                playerWC._weapons = new List<Ability>() { playerWC._weapons[0], myFactory.GetAbility(elementType) }; //Updates the players list of weaponries with the given ability from the factory.
                playerWC.UpdateWeapons(); //Updates the UI
            }
            else
            {
                if (playerWC._weapons.IndexOf(myFactory.GetAbility(elementType)) == -1)
                    playerWC._weapons.Add(myFactory.GetAbility(elementType));
                playerWC.UpdateWeapons();
            }
            Destroy(powerUp);
            duration = 0;
            canPickup = false;
        }
        if (duration != 0)
        {
            duration -= 1;
        }
        if (duration <= 0 && canPickup)
        {
            canPickup = false;
            duration = 0;
            interactText.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Powerup" && !canPickup) //If colliding with any tag with Player
        {
            interactText = collision.gameObject.transform.GetChild(0).gameObject;
            interactText.SetActive(true); 
            currentPos = collision.gameObject.transform.position;
            elementType = collision.gameObject.GetComponent<ElementTyping>().elementType;
            Debug.Log(elementType);
            canPickup = true;
            duration = pickUpTimer;
            powerUp = collision.gameObject;
        }
    }
}
