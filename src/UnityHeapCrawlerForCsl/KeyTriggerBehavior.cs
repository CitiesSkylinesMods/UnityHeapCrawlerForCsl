using System;
using UnityEngine;

namespace UnityHeapDumpForCsl
{
    public class KeyTriggerBehavior : MonoBehaviour
    {
        public void Update()
        {
            var controlPressed = Input.GetKey(KeyCode.LeftControl)
                || Input.GetKey(KeyCode.RightControl);
            if (controlPressed && Input.GetKeyDown(KeyCode.H))
            {
                OnKeysPressed();
            }
        }

        public event Action? KeysPressed;

        private void OnKeysPressed()
        {
            KeysPressed?.Invoke();
        }
    }
}
