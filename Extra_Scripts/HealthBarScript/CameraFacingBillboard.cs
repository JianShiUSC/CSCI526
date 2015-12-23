using UnityEngine;
using System.Collections;

/// <summary>
/// WORLD SPACE CANVAS FACES PLAYER AT ALL TIMES
/// </summary>
public class CameraFacingBillboard : MonoBehaviour
{
    void Update()
    {
       	if (Camera.main != null) {
			transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
		}
    }
}