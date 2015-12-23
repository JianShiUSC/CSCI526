using UnityEngine;
using System.Collections;

public class Trap5BlockDisappear : MonoBehaviour {
		
		public GameObject Door;
	    bool IsClosed= true;
		public void OpenDoor( bool BlockControl)
		{
		if (BlockControl == true && IsClosed == true) {
			Door.GetComponent<Animation> ().Play ("open");
			IsClosed = false;

		} else if (BlockControl == true && IsClosed == false) 
		{
			Door.GetComponent<Animation> ().Play ("close");
			IsClosed = true;
		}

		
		}
}
