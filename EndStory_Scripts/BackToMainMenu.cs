using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("backToMainMenu", 18f);
	}

	private void backToMainMenu () {
		Application.LoadLevel ("MenuScene");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
