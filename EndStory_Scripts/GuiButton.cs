using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ThirdPersonRPG.Player{
	
	public class GuiButton : MonoBehaviour {
		GameObject obj;
		Energy en;
		PlayerHealth ph;
		GameObject can;
		PauseManager pause;
		//public Texture icon;
		public GameObject GameOverScreen;
//		public GuiButton GameOverMan;
		public Font f;
		GUIStyle smallFont;

		void Awake()
		{
			obj=GameObject.FindGameObjectWithTag("Player");
			en = obj.GetComponent<Energy> ();
			ph = obj.GetComponent<PlayerHealth>();
			can = GameObject.FindGameObjectWithTag("Paused Canvas");
			pause = can.GetComponent<PauseManager>();
			//pause = GetComponent<PauseManager> ();
//			GameOverMan = GetComponent<GuiButton>();
		}
		
		
		public void OnGUI () {
			if(ph.isDead)
			{
				smallFont = new GUIStyle();
				// Make a background box
				GUIStyle myStyle = new GUIStyle(GUI.skin.box);
				myStyle.fontSize = 200;
				GUI.skin.font = f;
				GUI.Box(new Rect(0, 0,Screen.width, Screen.height),"");
				GUI.Label(new Rect(Screen.width/2-35, 40, 70, 60), "Game Over");
				
				// Main Menue Button
				if(GUI.Button(new Rect(Screen.width/2-60,100,120,60), "Main Menue")) {
					Application.LoadLevel ("MenuScene");
				}

				if (GUI.Button (new Rect (Screen.width/2-60, 280, 120, 60), "Load")) {
					pause.Load();
					can.GetComponent<Canvas>().enabled = !(can.GetComponent<Canvas>().enabled);
					GameOverScreen.GetComponentInChildren<Image>().color = new Color(0f, 0f, 0f, 0f);
					GameOverScreen.SetActive(false);
				}

				//coins>500 Save Me active

				if(en.currentcoins<500)
					GUI.enabled = false;
				else
					GUI.enabled = true;

				// Save Me button.
				if(GUI.Button(new Rect(Screen.width/2-60,180,120,60), "Save Me")) {
					en.collect_coins (-500);
					ph.Restart();
				}
				GUI.Label(new Rect(Screen.width/2-35,240,70,20), "500 Coins");
			}
		}
		//private void InitStyles()
		//{
		//if( currentStyle == null )
		//{
		//currentStyle = new GUIStyle( GUI.skin.box );
		//currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		//}
		//}
	}
}
