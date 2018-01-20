using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class meDICONE : MonoBehaviour {
	public int interval = 3;
	private DataTime LastTime;
	public List<string> countries;
	private System.Random random;

	// Use this for initialization
	void Start () {
		LastTime = DataTime.Now;
		random = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
		string country;
		if (DateTime.Now > LastTime.AddSeconds (interval)) 
		{
			LastTime = DataTime.Now
			country = countries[random.Next(countries.Count)];
			Debug.log(country);
		}
	}
}
