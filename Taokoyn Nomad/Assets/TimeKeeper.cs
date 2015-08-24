using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour {


	public enum Days
	{
		Vydir,Waelir,Raewir,Qenwir,Renthir,Mernir,Tresdir,Fraewir,Heswir
	}
	public enum Months
	{
		Vendellan, Kasellan, Filessan, Quallin, Tirrin, Pyccin, Naellian, Merrilien, Ravirren, Jiessin, Fraessin
	}

	public float time = 0f;
	float timeMax = 25f;
	public float timeFlowSpeed = 1f;
	public Days curDay = Days.Vydir;
	public int weekNr = 0;
	public Months curMonth = Months.Vendellan;
	public int year = 1;

	public Text timeText;

	private static TimeKeeper _instance;
	public static TimeKeeper instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<TimeKeeper>();
				
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

		if (time < 25) {
			time += Time.deltaTime * timeFlowSpeed;
		} else {
			time = 0f;
			AdvanceDay();
		}

		WriteOutTime ();
	
	}



	void AdvanceDay () {
		if (curDay == Days.Heswir) {
			curDay = Days.Vydir;
			AdvanceWeek();
		} else {
			curDay++;
		}
	}

	void AdvanceWeek(){
		if (weekNr == 4) {
			weekNr = 1;
			AdvanceMonth();
		} else {
			weekNr++;
		}
	}

	void AdvanceMonth(){
		if (curMonth == Months.Fraessin) {
			curMonth = Months.Vendellan;
			AdvanceYear();
		} else {
			curMonth++;
		}
	}

	void AdvanceYear(){
		year++;
	}


	void WriteOutTime(){
		switch (weekNr) {
		case 1:
			timeText.text = ""+time+"\nFirst "+curDay+"\nin "+curMonth+"\n Year "+year;
			break;
		case 2:
			timeText.text = ""+time+"\nSecond "+curDay+"\nin "+curMonth+"\n Year "+year;
			break;
		case 3:
			timeText.text = ""+time+"\nThird "+curDay+"\nin "+curMonth+"\n Year "+year;
			break;
		case 4:
			timeText.text = ""+time+"\nFourth "+curDay+"\nin "+curMonth+"\n Year "+year;
			break;
		}


	}


}
