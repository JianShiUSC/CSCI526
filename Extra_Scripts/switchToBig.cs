using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class switchToBig : MonoBehaviour {

	public GameObject BigMapCamera;
	public GameObject SwitchToMinButton;
	public GameObject BigMapImg;
	public GameObject border;
	public GameObject MiniMapCamera;
	public GameObject ZoomIn;
	public GameObject ZoomOut;
	public GameObject SwitchToBigButton;
	// Use this for initialization
	void Start () {
		BigMapImg.SetActive (false);
		BigMapCamera.SetActive (false);
		SwitchToMinButton.SetActive (false);
		border.SetActive (false);
		MiniMapCamera.SetActive (true);
		ZoomIn.SetActive (true);
		ZoomOut.SetActive (true);
		SwitchToBigButton.SetActive (true);
	}

	// Update is called once per frame
	void Update () {

	}
	public void SwitchToBig () {
		BigMapImg.SetActive (true);
		BigMapCamera.SetActive (true);
		SwitchToMinButton.SetActive (true);
		border.SetActive (true);
		MiniMapCamera.SetActive (false);
		ZoomIn.SetActive (false);
		ZoomOut.SetActive (false);
		SwitchToBigButton.SetActive (false);

	}
}
