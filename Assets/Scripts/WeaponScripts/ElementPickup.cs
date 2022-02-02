using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElementFactory;

//This script creates an abilityFactory that returns the correct element 
// to the player's weapons

public class ElementPickup : MonoBehaviour
{
    public string elementType;
    AbilityFactory myFactory = new AbilityFactory();
    public GameObject player;
    void Start()
    {
    player = GameObject.Find("Player");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        PlayerWeaponController cs = player.GetComponent<PlayerWeaponController>();
        if (cs.weapons.Count==2)
        {
            cs.weapons = new List<Ability>(){cs.weapons[0], myFactory.GetAbility(elementType)};
            cs.UpdateWeapons();
        }
        else
        {
            cs.weapons.Add(myFactory.GetAbility(elementType));
            cs.UpdateWeapons();
        }
        Destroy(gameObject);
        }
    }
}
