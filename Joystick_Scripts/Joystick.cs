using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

		Image joystick;

		Vector3 m_StartPos;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

		void OnEnable()
		{
			CreateVirtualAxes();
		}

        void Start()
        {
            m_StartPos = transform.position;
			joystick = gameObject.GetComponent<Image> ();
        }

		void UpdateVirtualAxes(Vector3 value)
		{
			var delta = m_StartPos - value;
			delta.y = -delta.y;
			delta /= MovementRange;
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Update(-delta.x);
			}

			if (m_UseY)
			{
				m_VerticalVirtualAxis.Update(delta.y);
			}
		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				if (!CrossPlatformInputManager.AxisExists(horizontalAxisName)) {
					m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
					CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
				} else {
					m_HorizontalVirtualAxis = CrossPlatformInputManager.VirtualAxisReference(horizontalAxisName);
				}
			}
			if (m_UseY)
			{
				if (!CrossPlatformInputManager.AxisExists(verticalAxisName)) {
					m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
					CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
				} else {
					m_VerticalVirtualAxis = CrossPlatformInputManager.VirtualAxisReference(verticalAxisName);
				}
			}
		}

		public void OnDrag(PointerEventData data)
		{

			Vector3 newPos = Vector3.zero;

			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				delta = Mathf.Clamp(delta, - MovementRange, MovementRange);//
				newPos.x = delta;
			}

			if (m_UseY)
			{
				int delta = (int)(data.position.y - m_StartPos.y);
				delta = Mathf.Clamp(delta, -MovementRange, MovementRange);
				newPos.y = delta;
			}
			//transform.position = Vector3.ClampMagnitude( new Vector3(newPos.x, newPos.y, newPos.z), MovementRange) + m_StartPos;
			transform.position = new Vector3(m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);
			UpdateVirtualAxes(transform.position);
		}

		public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
			joystick.color = new Color32 (255, 255, 255, 100);
		}


		public void OnPointerDown(PointerEventData data) {
			joystick.color = new Color32 (255, 255, 255, 255);
		}

//		void OnDisable()
//		{
//			// remove the joysticks from the cross platform input
//			if (m_UseX)
//			{
//				m_HorizontalVirtualAxis.Remove();
//			}
//			if (m_UseY)
//			{
//				m_VerticalVirtualAxis.Remove();
//			}
//		}
	}
}