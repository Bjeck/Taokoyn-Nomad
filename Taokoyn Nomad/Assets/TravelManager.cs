using UnityEngine;
using System.Collections;

public class TravelManager : MonoBehaviour {

	bool inTravel { get{return this;} }

	public GameObject UIObject;
	public GameObject TravelUI;
	public GameObject VillageUI;
	public GameObject light;


	private static TravelManager _instance;
	public static TravelManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<TravelManager>();
				
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

	void Start(){
		UIObject.SetActive (true);
		ExitTravel ();

	}



	public void EnterTravel(){
		TravelUI.SetActive (true);
		VillageUI.SetActive (false);
		Quaternion rot = new Quaternion(); rot.eulerAngles = new Vector3 (0, 180f, 0);
		Camera.main.transform.rotation = rot;
		light.transform.Rotate (180f, 180f, 180f);
	}

	public void ExitTravel(){
		TravelUI.SetActive (false);
		VillageUI.SetActive (true);
		Quaternion rot = new Quaternion(); rot.eulerAngles = new Vector3 (0, 0, 0);
		Camera.main.transform.rotation = rot;
		light.transform.Rotate (180f, 180f, 180f);
	}
}