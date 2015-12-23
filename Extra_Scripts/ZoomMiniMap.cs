using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZoomMiniMap : MonoBehaviour {
	
	//public Transform playerIcon;
	public float speed = 10f;
	Camera c;
	bool canZoomIn;
	bool canZoomOut;
	//float ratio = 0f;
	void Start () 
	{
		c = GetComponent<Camera> ();
		canZoomIn = false;
		canZoomOut = false;
	//	ratio = playerIcon.localScale.x / c.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (canZoomIn)
		{
			c.orthographicSize -= speed * Time.deltaTime;
		//	playerIcon.localScale -= (new Vector3(ratio,ratio,0f)) * speed * Time.deltaTime;
		}
		else if (canZoomOut)
		{
			c.orthographicSize += speed * Time.deltaTime;
		//	playerIcon.localScale += (new Vector3(ratio,ratio,0f)) * speed * Time.deltaTime;
		}
		c.orthographicSize = Mathf.Clamp (c.orthographicSize, 10f, 50f);
	//	playerIcon.localScale = new Vector3 (Mathf.Clamp (playerIcon.localScale.x, ratio * 30f, ratio * 300f), Mathf.Clamp (playerIcon.localScale.x, ratio * 30f, ratio * 300f), 1f);
	
	}
	public void ZoomIn()
	{
		canZoomIn = true;
	}

	public void ZoomOut()
	{
		canZoomOut = true;
	}

	public void UnZoom()
	{
		canZoomOut = canZoomIn = false;
	}
}


