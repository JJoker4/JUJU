using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerAttributes : MonoBehaviour {

	public string playerName;
	[HideInInspector]
	public int life, energy, oxygen, experiencePoints, modifierValue, level, maxValues;


	public void Start ()
	{
		maxValues = 100;
	}


	public void takeLife (int amount)
	{
		life -= amount;
	}

	public void takeEnergy (int amount)
	{
		energy -= amount;
	}

	public void takeOxygen (int amount)
	{
		oxygen -= amount;
	}


	public void levelUp ()
	{
		level += 1;
		life += modifierValue;
		energy += modifierValue;
		maxValues += modifierValue;
	}
}
