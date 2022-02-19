using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElementFactory;
//Cleon Doan
//This script creates an abilityFactory that returns the correct element 
// to the player's weapons

public class ElementPickup : MonoBehaviour
{
    public string elementType;
    AbilityFactory myFactory = new AbilityFactory(); //create a new abilit/Element Factory

    void Start()
    {
    }

    private void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //If colliding with any tag with Player
        {
            PlayerWeaponController cs = collision.gameObject.GetComponent<PlayerWeaponController>(); // Retrieves the player script of weapon controller to change variables and call its UI update function
            if (cs.weapons.Count==2)
            {
                cs.weapons = new List<Ability>(){cs.weapons[0], myFactory.GetAbility(elementType)}; //Updates the players list of weaponries with the given ability from the factory.
                cs.UpdateWeapons(); //Updates the UI
            }
            else
            {
                if (cs.weapons.IndexOf(myFactory.GetAbility(elementType)) == -1)
                    cs.weapons.Add(myFactory.GetAbility(elementType));
                cs.UpdateWeapons();
            }
            Destroy(gameObject);
        }
    }
}
