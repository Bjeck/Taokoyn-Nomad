using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Animal {
	public string name;
	public GenderTypes gender;
	public int age;
	public int ageOfDeath;

}

public class Animals : MonoBehaviour {

	public List<Animal> animals = new List<Animal>();
	public bool createAnimalTrigger = false;
	public string createAnimalName;
	int animalCounterNr = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (createAnimalTrigger) {
			if(createAnimalName == null || createAnimalName == ""){
				CreateAnimal(animalCounterNr.ToString(),Random.Range(5,10));
			}
			else{
				CreateAnimal(name,Random.Range(5,10));
			}
			createAnimalTrigger = false;
		}
	
	}



	public void CreateAnimal(string s, int ag){
		Animal a = new Animal ();
		a.name = s;

		int ran = Random.Range (0, 2);
		if (ran == 0) {
			a.gender = GenderTypes.Male;
		} else {
			a.gender = GenderTypes.Female;
		}

		a.age = ag;

		float ragd = Random.Range(1.2f,3f);
		ragd = Mathf.Pow(ragd,3f);


		a.ageOfDeath = (int)ragd;

		if (a.ageOfDeath < a.age) {
			a.ageOfDeath += a.age;
		}

		Debug.Log ("AGE "+ag+" "+a.ageOfDeath);

		animals.Add (a);

		FamilyResources.instance.UpdateAmountOfAnimals ();
	}

}
