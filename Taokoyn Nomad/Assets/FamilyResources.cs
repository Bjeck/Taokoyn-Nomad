using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FamilyResources : MonoBehaviour {

	//RESOURCES
	public int food;
	public int clothing;
	public int usedClothing;
	public int tents;
	public int usedTents;
	public int weaponry;
	public int money;
	public int luxury_resources;

	public Text resourceText;
	public Text familyText;

	public int amtOfPeople;
	public int amtOfAnimals;


	public Animals animalsInFamily;


	private static FamilyResources _instance;
	public static FamilyResources instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<FamilyResources>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
	}




	public void MorningTick(){

	}


	public void DinnerTick(){
		food -= amtOfPeople;
	}


	public void DayTick(){



	}


	public void UpdateAmountOfPeople(){
		amtOfPeople = EntityManager.instance.people.Count;
		usedClothing = amtOfPeople;
		usedTents = amtOfPeople / (int)2f;
	}

	public void UpdateAmountOfAnimals(){
		amtOfAnimals = animalsInFamily.animals.Count;
	}



	public void UpdateText(){
		if (food < 0) {
			resourceText.text = "<color=red>Food: " + food + ".</color> ";
		} else {
			resourceText.text = "Food: " + food + ". ";
		}

		if (usedClothing > clothing) {
			resourceText.text += "<color=red>Clothing: "+usedClothing+"/"+clothing+".</color> "; 
		} else {
			resourceText.text += "Clothing: "+usedClothing+"/"+clothing+". "; 
		}

		if (usedTents > tents) {
			resourceText.text += "<color=red>Tents: "+usedTents+"/"+tents+".</color> "; 
		} else {
			resourceText.text += "Tents: "+usedTents+"/"+tents+". "; 
		}

		resourceText.text += "Weaponry: " + weaponry + ". ";
		resourceText.text += "Money: " + money + ". ";
		resourceText.text += "Luxuries: "+luxury_resources+".";


		familyText.text = "People: " + amtOfPeople+". Animals: "+amtOfAnimals+".";
	}
}
