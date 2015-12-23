using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarImage : MonoBehaviour {
	public GameObject background;
	public GameObject bar;
	public Sprite img;

	// Use this for initialization
	void Awake () {
		Image bgimg = background.AddComponent<Image> ();
		bgimg.sprite = img;
		bgimg.color = Color.gray;
		bgimg.preserveAspect = true;

		Image barimg = bar.AddComponent<Image> ();
		barimg.sprite = img;
		barimg.color = Color.red;
		barimg.preserveAspect = true;
		barimg.type = Image.Type.Filled;
		barimg.fillMethod = Image.FillMethod.Horizontal;
	}
}
