using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MagicBarImage : MonoBehaviour {
	public GameObject background;
	public GameObject bar;
	public Sprite img;
	
	// Use this for initialization
	void Awake () {
		Image bgimg = background.AddComponent<Image> ();
		bgimg.sprite = img;
		bgimg.color = Color.gray;
		bgimg.preserveAspect = false;
		
		Image barimg = bar.AddComponent<Image> ();
		barimg.sprite = img;
		barimg.color = Color.blue;
		barimg.preserveAspect = false;
		barimg.type = Image.Type.Filled;
		barimg.fillMethod = Image.FillMethod.Horizontal;
	}
}
