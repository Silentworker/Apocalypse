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
            if (OnMouseDownHandler != null) { OnMouseDownHandler(); }
        }

        void OnMouseUp()
        {
            if (OnMouseUpHandler != null) { OnMouseUpHandler(); }
        }
    }
}
