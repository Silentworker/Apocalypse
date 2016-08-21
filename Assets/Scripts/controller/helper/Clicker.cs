using UnityEngine;

namespace Assets.Scripts.controller.helper
{
    public class Clicker : MonoBehaviour
    {
        public delegate void MouseActionHandler();
        public MouseActionHandler OnMouseDownHandler;
        public MouseActionHandler OnMouseUpHandler;

        void OnMouseDown()
        {
#if UNITY_EDITOR

            if (OnMouseDownHandler != null) { OnMouseDownHandler(); }
#endif
        }

        void OnMouseUp()
        {
#if UNITY_EDITOR
            if (OnMouseUpHandler != null) { OnMouseUpHandler(); }
#endif
        }

        void Update()
        {
#if (UNITY_IPHONE || UNITY_ANDROID)
            if (Input.touchCount > 0)
            {
                if (OnMouseDownHandler != null) { OnMouseDownHandler(); }
            }
#endif
        }
    }
}
