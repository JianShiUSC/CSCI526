using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 60, 0) * Time.deltaTime);
	}
}