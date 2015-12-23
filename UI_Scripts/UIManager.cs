using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public void BackToHome()
	{
		Application.LoadLevel ("MenuScene");
	}

	public void control_Panel()
	{
		Application.LoadLevel ("Control_Panel");
	}
}
