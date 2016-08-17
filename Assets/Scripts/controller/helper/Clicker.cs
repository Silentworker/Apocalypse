using UnityEngine;

namespace Assets.Scripts.controller.helper
{
    public class Clicker : MonoBehaviour
    {
        public delegate void ClickHandler();
        public ClickHandler OnClickHandler;

        void OnMouseDown()
        {
            if (OnClickHandler != null)
            {
                OnClickHandler();
            }
        }
    }
}
