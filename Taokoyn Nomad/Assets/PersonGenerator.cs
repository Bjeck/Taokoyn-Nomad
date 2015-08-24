using UnityEngine;
using System.Collections;

public class PersonGenerator : MonoBehaviour {


	public string personName;
	public int personNameCounter = 0;
	public bool createPersonTrigger = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (createPersonTrigger) {
			if(personName==null || personName==""){
				CreatePerson(personNameCounter.ToString());
				personNameCounter++;
			}
			else{
				CreatePerson(personName);
			}

			createPersonTrigger = false;
		}
	}



	public void CreatePerson(string name){
		GameObject person = Instantiate(Resources.Load("Person", typeof(GameObject))) as GameObject;
		Person p = person.AddComponent<Person> ();
		person.name = name;


		p.name = name;
		p.strength = Random.Range (EntityManager.instance.StatMin, EntityManager.instance.StatMax);
		p.charisma = Random.Range (EntityManager.instance.StatMin, EntityManager.instance.StatMax);
		p.wit = Random.Range (EntityManager.instance.StatMin, EntityManager.instance.StatMax);
		p.knowledge = Random.Range (EntityManager.instance.StatMin, EntityManager.instance.StatMax);
		p.agility = Random.Range (EntityManager.instance.StatMin, EntityManager.instance.StatMax);

		p.agressivity = Random.Range (EntityManager.instance.TraitMin, EntityManager.instance.TraitMax);
		p.cynicism = Random.Range (EntityManager.instance.TraitMin, EntityManager.instance.TraitMax);
		p.honesty = Random.Range (EntityManager.instance.TraitMin, EntityManager.instance.TraitMax);
		p.lust = Random.Range (EntityManager.instance.TraitMin, EntityManager.instance.TraitMax);

		p.happiness = 0;
		p.food_Security = 0;
		p.religious_Satisfaction = 0;
		p.safety = 0;

		int gSel = Random.Range (0, 100);
		if (gSel < 45) {
			p.gender = GenderTypes.Male;
		} else if (gSel >= 45 && gSel < 90) {
			p.gender = GenderTypes.Female;
		} else {
			p.gender = GenderTypes.Trans;
		}

		int sSel = Random.Range (0, 100);

		if (p.gender == GenderTypes.Male) {

			if(sSel < 90){
				p.sexuality = SexualityTypes.Female;
			}
			else if(sSel >=90 && sSel < 94){
				p.sexuality = SexualityTypes.Male;
			}
			else if(sSel >=94 && sSel < 98){
				p.sexuality = SexualityTypes.Bi;
			}
			else{
				p.sexuality = SexualityTypes.Neither;
			}

		}
		else if (p.gender == GenderTypes.Female) {
			
			if(sSel < 90){
				p.sexuality = SexualityTypes.Male;
			}
			else if(sSel >=90 && sSel < 94){
				p.sexuality = SexualityTypes.Female;
			}
			else if(sSel >=94 && sSel < 98){
				p.sexuality = SexualityTypes.Bi;
			}
			else{
				p.sexuality = SexualityTypes.Neither;
			}
			
		}
		else if (p.gender == GenderTypes.Trans) {
			
			if(sSel < 40){
				p.sexuality = SexualityTypes.Male;
			}
			else if(sSel >=40 && sSel < 80){
				p.sexuality = SexualityTypes.Female;
			}
			else if(sSel >=80 && sSel < 90){
				p.sexuality = SexualityTypes.Bi;
			}
			else{
				p.sexuality = SexualityTypes.Neither;
			}
			
		}




		EntityManager.instance.people.Add (name,p);




	}


}
