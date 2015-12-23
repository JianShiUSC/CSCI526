using UnityEngine;
using System.Collections;


public class DamageEnemyWord : MonoBehaviour {
	
	private Vector3 position;
	//	private Vector3 screenPointPosition;
	private Camera cameraHold;
	private string text;
//	private Transform enemytransform;
	private GameObject[] enemies;
	private float x;
	private float temp_y;
	private Vector3 p;
	private Font font;
	private GUIStyle fontstyle;
	//public GameObject player;
	// Use this for initialization
	
	void Start () {
		//cameraHold = Camera.main;
		//screenPointPosition = cameraHold.WorldToScreenPoint (position);
		//enemytransform = GameObject.FindGameObjectWithTag("Enemy").transform;
		p = Camera.main.WorldToScreenPoint (transform.position);
		float ty = Camera.main.WorldToScreenPoint (transform.position).y;
		float diff = Mathf.Abs (Screen.height / 2 - ty);
		if (ty <= Screen.height / 2) {		
			p.y = Screen.height / 2 + diff;
		} else {
			p.y = Screen.height / 2 - diff;
		}

		fontstyle = new GUIStyle ();
		fontstyle.font = font;
		fontstyle.fontSize = 70;
		fontstyle.normal.textColor = Color.yellow;

		//	x = player.position.x;
		//	y = player.position.y;
	}

	void Awake() {
		font = (Font)Resources.Load("Curse of the Zombie");
	}
	
	// Update is called once per frame
//	void Update () {
//		//screenPointPosition.y -= 1;
//		//Debug.Log ("sfhkadlg" + temp_y);
//		//temp_y -= 10;
//	}

	public static void ShowMessage(string texto, Vector3 position)
	{
		GameObject newInstance = new GameObject("Damage Enemy");
		var damagePopUp = newInstance.AddComponent<DamageEnemyWord> ();
		newInstance.transform.position = position;
		damagePopUp.text = texto;
	}
	void OnGUI(){
		fontstyle.fontSize -= 1;
		p.y -= 3;
		p.x += 0.7f;
		GUI.Label (new Rect (p.x-50, p.y-100, 200, 70), text, fontstyle);
		//Debug.Log ("x: " + x);
		//Debug.Log ("y: " + y);
		Destroy (gameObject, 1);
		//GUI.Label (new Rect (p.x, y, 200, 78),"");
	}
}
