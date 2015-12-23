using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ThirdPersonRPG.Player;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManagerScript : MonoBehaviour {
	public Text HeadText;
	public Text[] texts;
	private Text targetText = null;
	
	
	private void Loading() {
		HeadText.color = Color.red;
		targetText.color = Color.red;
		targetText.text = "LOADING...";
		foreach(Text text in texts) {
			if (text != targetText) {
				text.enabled = false;
			}
		}
	}
	
//	public void StartGame()
//	{
//		targetText = texts [0];
//		Loading ();
//		
//		Application.LoadLevel ("Demo6");
//	}
	
	public void StartGame()
	{
		//targetText = texts [0];
		//Loading ();
		
		Application.LoadLevel ("LevelChoose");
	}

	
//	public void LoadGame()
//	{
//		targetText = texts [1];
//		Loading ();
//		
//		PlayerInfo.playerinfo.Load ();
//		Application.LoadLevel (PlayerInfo.playerinfo.scene);
//	}


	public void LoadGame()
	{
		Application.LoadLevel ("SaveLoadPage");
	}


	
	public void QuitGame()
	{
		targetText = texts [3];
		Loading ();
		
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
	
	public void Option()
	{
		targetText = texts [2];
		//Loading ();
		
		Application.LoadLevel ("OptionScene");
	}
}