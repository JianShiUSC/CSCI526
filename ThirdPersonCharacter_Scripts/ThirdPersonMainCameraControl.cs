using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace ThirdPersonRPG.Player
{
	public class ThirdPersonMainCameraControl : MonoBehaviour {
		Transform m_Player;
		float m_Distance = 12.5f;
		float m_TurnAmount;
		float m_MovingTurnSpeed = 360;
		float m_TurnSpeed = 2.25f;
		float m_StationaryTurnSpeed = 180;
		Vector3 m_CamMove;
		Transform m_Cam;
		Vector3 m_GroundNormal;
		Vector3 m_Offset;

		// Use this for initialization
		void Start () {
			// get the transform of the main camera
			if (Camera.main != null)
			{
				m_Cam = Camera.main.transform;
			}
			else
			{
				Debug.LogWarning(
					"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
				// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
			}

			m_Player = GameObject.FindGameObjectWithTag ("Player").transform;
			m_Offset = (m_Cam.position - m_Player.position).normalized * m_Distance;
			m_Cam.position = m_Player.position + m_Offset;
		}
		
		// Update is called once per frame
//		void Update () {
//		
//		}

		void Update () {
			float h = CrossPlatformInputManager.GetAxis("Multi Touch Input Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Multi Touch Input Vertical");

			// calculate move direction to pass to character
//			if (m_Cam != null)
//			{
//				// calculate camera relative direction to move:
//				m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
//				m_Move = h*m_Cam.right;
//			}
//			else
//			{
//				// we use world-relative directions in the case of no main camera
//				m_Move = v*Vector3.forward + h*Vector3.right;
//			}
			if (m_Player.gameObject.GetComponent<PlayerHealth> ().isDead) {
//				m_Cam.rotation *= Quaternion.FromToRotation(m_Cam.forward, Vector3.up) * Time.deltaTime;
//				if (m_Cam.rotation.eulerAngles != Quaternion.Euler) m_Cam.rotation *= Quaternion.AngleAxis(Quaternion.Angle(Quaternion.Euler(new Vector3(90, 0, 0)), m_Cam.rotation) * Time.deltaTime , m_Cam.right);
			} else {
				m_CamMove = h * m_Cam.right + v * m_Cam.up;
				CameraMove (m_CamMove);
			}
		}

		void CameraMove(Vector3 m_CamMove) {
			// CAMERA MOVEMENT
			if (m_CamMove.magnitude > 1f) m_CamMove.Normalize();
			m_CamMove = m_Cam.InverseTransformDirection(m_CamMove);

			Quaternion hq = Quaternion.AngleAxis(m_CamMove.x * m_TurnSpeed, Vector3.up);
			Quaternion vq = Quaternion.Euler (new Vector3 (0, 0, 0));

			if ( m_CamMove.y > 0.0f && m_Cam.rotation.eulerAngles.x <= 70f || m_Cam.rotation.eulerAngles.x >= 20f && m_CamMove.y < -0.0f) {
				vq = Quaternion.AngleAxis(m_CamMove.y * m_TurnSpeed, m_Cam.right);
			}

			m_Offset = vq * hq * m_Offset;
			m_Offset = m_Offset.normalized * m_Distance;
			m_Cam.position = m_Player.position + m_Offset;
			m_Cam.LookAt (m_Player.position);
//			m_Cam.rotation = Quaternion.Euler (new Vector3((vq * hq * m_Cam.rotation).eulerAngles.x, (vq * hq * m_Cam.rotation).eulerAngles.y, 0f));
			
//			RaycastHit hitInfo;
//			
//			if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo))
//			{
//				m_GroundNormal = hitInfo.normal;
//			}
//			else
//			{
//				m_GroundNormal = Vector3.up;
//			}
		}
	}
}