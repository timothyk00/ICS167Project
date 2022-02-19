using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cleon Doan
namespace ElementFactory
{

	//abstract class for type that ElementFactory will return : Ability
	public abstract class Ability
	{
	//abstract properties
	public abstract string element {get;}
	//class methods
	public abstract void useAbility(Vector3 playerPosition, Vector3 playerForward);
	}

	// classes that will inherit from Ability 
	public class FireElement : Ability
	{
		private string name = "Fire";
		public override string element
		{
			get{return name;}
		}
		public override void useAbility(Vector3 playerPosition,Vector3 playerForward)
		{
		GameObject fireBall = GameObject.Instantiate(Resources.Load("FireProjectile")) as GameObject;
			fireBall.transform.position = playerPosition + (playerForward * 3.8f);
			fireBall.transform.forward = playerForward;
		}
	}
	public class ElectricElement: Ability
	{
		private string name = "Electric";
		public override string element
		{
			get{return name;}
		}
		public override void useAbility(Vector3 playerPosition,Vector3 playerForward)
		{
		GameObject electricBolt = GameObject.Instantiate(Resources.Load("ElectricBolt")) as GameObject;
		electricBolt.transform.position = playerPosition+(playerForward*7f);
		electricBolt.transform.forward = playerForward;
		}
	}
	public class IceElement: Ability
	{
		private string name = "Ice";
		public override string element
		{
			get{return name;}
		}
		public override void useAbility(Vector3 playerPosition,Vector3 playerForward)
		{
		GameObject iceBall = GameObject.Instantiate(Resources.Load("IceProjectile")) as GameObject;
		iceBall.transform.position = playerPosition+(playerForward*3f);
		iceBall.transform.forward = playerForward;
		}
	}
	public class HealElement: Ability
	{
		private string name = "Heal";
		public override string element
		{
			get{return name;}
		}		
		public override void useAbility(Vector3 playerPosition,Vector3 playerForward)
		{
				GameObject healAura = GameObject.Instantiate(Resources.Load("HealAura")) as GameObject;
				healAura.transform.position = playerPosition;		
		}
	}
	public class EarthElement: Ability
	{
		private string name = "Earth";
		public override string element
		{
			get{return name;}
		}		public override void useAbility(Vector3 playerPosition,Vector3 playerForward)
		{
		GameObject earthBlock = GameObject.Instantiate(Resources.Load("EarthBlock")) as GameObject;
		earthBlock.transform.position = playerPosition+(playerForward*2);
		earthBlock.transform.forward = playerForward;
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
