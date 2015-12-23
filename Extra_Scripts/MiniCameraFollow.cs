using UnityEngine;
using System.Collections;

public class MiniCameraFollow : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(Target.position.x, transform.position.y, Target.position.z);
	}
}
