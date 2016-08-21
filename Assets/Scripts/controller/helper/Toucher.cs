using UnityEngine;

namespace Assets.Scripts.controller.helper
{
    public class Toucher : MonoBehaviour
    {
        private static RaycastHit _hit;

        public delegate void MouseActionHandler();

        public MouseActionHandler OnTouchDownHandler;
        public MouseActionHandler OnTouchUpHandler;

        private Touch _touch;

        void OnMouseDown()
        {
#if UNITY_EDITOR

            if (OnTouchDownHandler != null)
            {
                OnTouchDownHandler();
            }
#endif
        }

        void OnMouseUp()
        {
#if UNITY_EDITOR
            if (OnTouchUpHandler != null)
            {
                OnTouchUpHandler();
            }
#endif
        }

        void Update()
        {
#if (UNITY_IPHONE || UNITY_ANDROID)
            if (OnTouchDownHandler != null || OnTouchUpHandler != null)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        var ray = Camera.main.ScreenPointToRay(touch.position);

                        if (Physics.Raycast(ray, out _hit))
                        {
                            if (_hit.transform == transform)
                            {
                                _touch = touch;

                                if (OnTouchDownHandler != null)
                                {
                                    OnTouchDownHandler();
                                }
                            }
                        }
                    }
                    else if (touch.phase == TouchPhase.Ended && touch.fingerId == _touch.fingerId)
                    {
                        if (OnTouchUpHandler != null) { OnTouchUpHandler(); }
                    }
                }
            }
#endif
        }
    }
}