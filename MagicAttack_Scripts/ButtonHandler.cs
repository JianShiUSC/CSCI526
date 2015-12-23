using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace ThirdPersonRPG.Player
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
			gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 100);
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
			gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }
    }
}
