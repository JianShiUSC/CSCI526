using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace ThirdPersonRPG.Player
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class ThirdPersonTouchControl : MonoBehaviour {

		private NavMeshAgent m_Agent;
		private ThirdPersonCharacter m_Character;
		private Vector3 m_Dest;
		private bool m_Touchable = true;

		private GameObject[] m_Buttons;

		// Use this for initialization
		private void Start () {
			m_Buttons = GameObject.FindGameObjectsWithTag ("Button");

			m_Agent = GetComponent<NavMeshAgent> ();
			m_Character = GetComponent<ThirdPersonCharacter> ();
			m_Dest = m_Agent.transform.position;

			m_Agent.updateRotation = false;
			m_Agent.updatePosition = true;
		}

		private void FixedUpdate () {
			foreach(GameObject button in m_Buttons) {
				if (Input.touchCount > 0) {
					Debug.Log(button.GetComponent<RectTransform>().rect);
					Debug.Log(Input.GetTouch(0).position);
				}
				if (Input.touchCount > 0 && button.GetComponent<RectTransform>().rect.Contains(Input.GetTouch(0).position)) {
					m_Touchable = false;
					break;
				} else {
					m_Touchable = true;
				}
			}

			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && m_Touchable) {
				Ray camRay = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
				RaycastHit hit;
				if (Physics.Raycast (camRay, out hit)) {
					Vector3 pos = new Vector3 (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, hit.distance);
					m_Dest = Camera.main.ScreenToWorldPoint (pos);
				}
			}
			m_Agent.SetDestination (m_Dest);
			m_Character.Move (m_Agent.desiredVelocity, false);
		}
	}
}