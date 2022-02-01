using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementFactory
{
	//variables for elements



	//abstract class for type that ElementFactory will return : Ability
	public abstract class Ability : MonoBehaviour
	{
	//class variables
	public static float projectileSpeed = 10f;
	public GameObject fire;
	public GameObject electric;
	public GameObject earth;
	public GameObject ice;
	public GameObject heal; 

	//class methods
	public abstract void useAbility();
	}

	// classes that will inherit from Ability 
	public class FireElement : Ability
	{
		public override void useAbility()
		{
			GameObject intFire = Instantiate(fire, transform.position, Quaternion.identity);
			Rigidbody intFireRB = intFire.GetComponent<Rigidbody>();
			intFireRB.AddForce(Vector3.forward * projectileSpeed);
			Destroy(intFire, 3f);
		}
	}
	public class ElectricElement: Ability
	{
		public override void useAbility()
		{
		}
	}
	public class IceElement: Ability
	{
		public override void useAbility()
		{
		}
	}
	public class HealElement: Ability
	{
		public override void useAbility()
		{
		}
	}
	public class EarthElement: Ability
	{
		public override void useAbility()
		{
		}
	}

	//the actual factory that will return the correct element
	public class AbilityFactory
	{
		//GetAbility takes a string to decide which class type to return
		public Ability GetAbility(string abilityType)
		{
			switch(abilityType)
			{
				case "fire":
					return new FireElement();
				case "electric":
					return new ElectricElement();
				case "ice":
					return new IceElement();
				case "heal":
					return new HealElement();
				case "earth":
					return new EarthElement();
				default:
					return null;
			}
		}
	}

}

