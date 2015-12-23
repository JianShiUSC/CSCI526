using UnityEngine;
using System.Collections;
using ThirdPersonRPG.Player;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{
	public GameObject LoadingScene;
	public Image LoadingBar;

	public void Map_graveyard()
	{			
		PlayerInfo.playerinfo.Start ();
		PackageInfo.packageInfo.Start ();
//		Application.LoadLevel ("Demo6");
		StartCoroutine (LevelCoroutine(6));
	}
	public void Map_village()
	{			
		PlayerInfo.playerinfo.Start ();
		PackageInfo.packageInfo.Start ();
//		Application.LoadLevel ("Demo4");
		StartCoroutine (LevelCoroutine(4));
	}
	public void Map_dungeon()
	{			
		PlayerInfo.playerinfo.Start ();
		PackageInfo.packageInfo.Start ();
//		Application.LoadLevel ("Demo1");
		StartCoroutine (LevelCoroutine(1));
	}
	public void Map_castle()
	{			
		PlayerInfo.playerinfo.Start ();
		PackageInfo.packageInfo.Start ();
//		Application.LoadLevel ("Demo7");
		StartCoroutine (LevelCoroutine(7));
	}
	public void Map_fantasy()
	{		
		PlayerInfo.playerinfo.Start ();
		PackageInfo.packageInfo.Start ();
//		Application.LoadLevel ("Demo8");
		StartCoroutine (LevelCoroutine(8));
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
