using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchPoint : MonoBehaviour {
	
	public GameObject LoadingScene;
	public Image LoadingBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider Others)
	{
		if (Others.tag == "SwitchPointToDemo1") 
		{
			StartCoroutine (LevelCoroutine(1));
		}
		if (Others.tag == "SwitchPointToDemo4") 
		{
			StartCoroutine (LevelCoroutine(4));
		}
		if (Others.tag == "SwitchPointToDemo6") 
		{
			StartCoroutine (LevelCoroutine(6));
		}
		if (Others.tag == "SwitchPointToDemo7") 
		{
			StartCoroutine (LevelCoroutine(7));
		}
		if (Others.tag == "SwitchPointToDemo8") 
		{
			StartCoroutine (LevelCoroutine(8));
		}
	}
	
	IEnumerator LevelCoroutine(int level)
	{
		LoadingScene.SetActive (true);

		if (level == 1) {
			AsyncOperation async = Application.LoadLevelAsync ("Demo1");
			while (!async.isDone) {
				LoadingBar.fillAmount += async.progress / 10f;
				yield return null;
			}
		}
		if (level == 4) {
			AsyncOperation async = Application.LoadLevelAsync ("Demo4");
			while (!async.isDone) {
				LoadingBar.fillAmount += async.progress / 10f;
				yield return null;
			}
		}
		if (level == 6) {
			AsyncOperation async = Application.LoadLevelAsync ("Demo6");
			while (!async.isDone) {
				LoadingBar.fillAmount += async.progress / 10f;
				yield return null;
			}
		}
		if (level == 7) {
			AsyncOperation async = Application.LoadLevelAsync ("Demo7");
			while (!async.isDone) {
				LoadingBar.fillAmount += async.progress / 10f;
				yield return null;
			}
		}
		if (level == 8) {
			AsyncOperation async = Application.LoadLevelAsync ("Demo8");
			while (!async.isDone) {
				LoadingBar.fillAmount += async.progress / 10f;
				yield return null;
			}
		}
	}
}
