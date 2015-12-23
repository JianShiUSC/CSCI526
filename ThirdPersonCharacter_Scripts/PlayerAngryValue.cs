using UnityEngine;
using System.Collections;

public class PlayerAngryValue : MonoBehaviour {

	public int currentAngryValue = 0;
	public int maxAngryValue = 500;

	public void getAngryValue(int amount)
	{
		if (currentAngryValue + amount * 2 > maxAngryValue) 
		{
			currentAngryValue = maxAngryValue;
		}
		else
		{
			currentAngryValue += amount * 2;
		}
	}
}
