using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace ThirdPersonRPG.Player
{
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class ThirdPersonAccelerometerControl : MonoBehaviour 
	{
		private ThirdPersonCharacter m_Character;
		private Transform m_Cam;
		private Vector3 m_CamForward;
		private Vector3 m_Move;
		private Vector3 m_Accelerometer;

		// Use this for initialization
		private void Start () {
			if (Camera.main != null)
			{
				m_Cam = Camera.main.transform;
			} else {
				Debug.LogWarning(
					"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			}
			
			m_Character = GetComponent<ThirdPersonCharacter>();
		}

		private void FixedUpdate () {
			m_Accelerometer = Input.acceleration;
			if (m_Cam != null)
			{
				m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
				m_Move = -m_Accelerometer.z * m_CamForward + m_Accelerometer.x * m_Cam.right;
			}
			else
			{
				m_Move = -m_Accelerometer.z * Vector3.forward + m_Accelerometer.x * Vector3.right;
			}
			m_Character.Move(m_Move, false);
		}
	}
}
