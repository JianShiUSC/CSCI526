using UnityEngine;
using System.Collections;
namespace ThirdPersonRPG.Player 
{
public class WalkDemo6 : MonoBehaviour 
	{
	float xx = 0f,zz=0f,yy=0f;
	Vector3 zero=new Vector3(0,0,0);
	Rigidbody rb;
	float force=280.0f;
	Animator ani;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
		{
		xx= transform.position.x;
		zz = transform.position.z;
		yy = transform.position.y;


		if (zz > -30.65 && zz < 30.22)
		{
			if (xx <= -30.2f) {
				rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
				ani.SetBool ("isBack", true);
			} else if (xx <= 30.22f) {
				ani.SetBool ("isBack", false);
			} else {//xx>30.22f
				ani.SetBool ("isBack", true);
				rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
			}
		} else {
			ani.SetBool ("isBack", true);
			if (zz <= -30.65) {
				rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
				
			} else {//zz>=30.22
				rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
				}
			}
		}
	}
}
