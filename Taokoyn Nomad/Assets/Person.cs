using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour {

	public string name;

	//STATS
	public int strength;
	public int charisma;
	public int wit;
	public int knowledge;
	public int agility;

	//TRAITS
	public int agressivity;
	public int cynicism;
	public int honesty;
	public int lust;

	public GenderTypes gender;
	public SexualityTypes sexuality;

	//VALUES
	public int happiness { get{return this.happiness;} set{if(value>EntityManager.instance.ValueMin && value<EntityManager.instance.ValueMax){this.happiness = value;}}}
	public int food_Security {get{return this.food_Security;} set{if(value>EntityManager.instance.ValueMin && value<EntityManager.instance.ValueMax){this.food_Security = value;}}}
	public int religious_Satisfaction {get{return this.religious_Satisfaction;} set{if(value>EntityManager.instance.ValueMin && value<EntityManager.instance.ValueMax){this.religious_Satisfaction = value;}}}
	public int safety {get{return this.safety;} set{if(value>EntityManager.instance.ValueMin && value<EntityManager.instance.ValueMax){this.safety = value;}}}


	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

