using UnityEngine;
using System.Collections;
using ThirdPersonRPG.Player;

public class CharacterScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i<7; i++) 
		{
			transform.GetChild(i).GetComponent<CharacterSlot>().index = i;
		}
	}
}
