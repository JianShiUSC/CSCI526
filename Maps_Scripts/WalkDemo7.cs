using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player
{
	public class WalkDemo7 : MonoBehaviour 
	{

//		//		floor 0 
//		float xmax0=48f,xmin0=-26f,zmax0=55f,zmin0=-12f;
//
//		//		floor 1 
//		float xmax01=48f,xmin01=-26f,zmax01=60f,zmin01=-16.3f;
//
//		//		floor 2 part1
//		float xmax1=-13.9f,xmin1=-26.35f,zmin1=88.2f;
//		//		floor 2 part2
//		float xmax2=-18.3f,xmin2=-21.76f,zmax2=88.2f,zmin2=46f;
//		//		floor 2 part3
//		float xmin3=-26.5f,zmax3=46f;
//		float delta=0.02f;
//		float ymax=9.0f,ymin = 1.0f; 
		float xx = 0f,zz=0f,yy=0f;
		Vector3 zero=new Vector3(0,0,0);
		Rigidbody rb;
		float force=180.0f;
		Animator ani;
		
		// Use this for initialization
		void Start () 
		{
			rb = GetComponent<Rigidbody>();
			ani = GetComponent<Animator> ();
		}
		void Update()
		{
			xx= transform.position.x;
			zz = transform.position.z;
			yy = transform.position.y;
//						Debug.Log (xx+"x");
			//			Debug.Log (zz+"z");
//			floor 0
			if (yy <= 1f) {
				if (zz > -12 && zz < 55) {
					if (xx <= -26f) {
						//idle, add back force
						//					P.enabled = false;
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
						ani.SetBool ("isBack", true);
					} else if (xx <= 48f) {
						//do nothing
						//					P.enabled = true;
						ani.SetBool ("isBack", false);
					} else {
						//idle, add force
						//					P.enabled = false;
						//					Debug.Log("back");
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				} else {
					ani.SetBool ("isBack", true);
					if (zz <= -12) {
						rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);

					} else {
						rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);

					}

				}
			} else if (yy < 9f && yy > 1f) 
			{
				if(zz>-16.3f && zz<60f)
				{
					if (xx <= -26f) {
						//idle, add back force
						//					P.enabled = false;
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
						ani.SetBool ("isBack", true);
					} else if (xx <= 48f) {
						//do nothing
						//					P.enabled = true;
						ani.SetBool ("isBack", false);
					} else {
						//idle, add force
						//					P.enabled = false;
						//					Debug.Log("back");
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}


				}else{
					ani.SetBool ("isBack", true);
					if (zz <= -16.3) {
						rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
						
					} else {
						rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
						
					}
				}

			} else{//yy>=9
//				floor2 part1
				if(zz>88.2f)
				{
					if (xx < -26.39f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else if(xx<-13.2f){
						ani.SetBool ("isBack", false);
					} else{//>-13.9
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				}
				else if(46f<=zz&&zz<=88.2) //	floor2 part2
				{
					if (xx < -21.81f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else if(xx<-18.12f){
						ani.SetBool ("isBack", false);
					} else{//>-18.12
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				} else { //zz<46f
					if (xx < -26.5f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else{//>-26.5
						ani.SetBool ("isBack", false);
					}
				}
			}
		}
		
	}
}

