using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Clothing {

	public Person personWhoWearsMe;

	public Clothing(Person p){
		personWhoWearsMe = p;
	}

}





public class ClothingContainer : MonoBehaviour {

	public List<Clothing> clothings = new List<Clothing>();




	private static ClothingContainer _instance;
	public static ClothingContainer instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ClothingContainer>();
				
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
	
	}
}
