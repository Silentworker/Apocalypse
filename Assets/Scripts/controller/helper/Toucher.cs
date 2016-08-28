using UnityEngine;

namespace Assets.Scripts.controller.helper
{
    public class Toucher : MonoBehaviour
    {


        public delegate void MouseActionHandler();

        public MouseActionHandler OnTouchDownHandler;
        public MouseActionHandler OnTouchUpHandler;

        private int _touchID;

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
                        if (DoesHitButton(touch))
                        {
                            _touchID = touch.fingerId;

                            if (OnTouchDownHandler != null)
                            {
                                OnTouchDownHandler();
                            }
                        }
                    }
                    else if (touch.phase == TouchPhase.Ended && touch.fingerId == _touchID)
                    {
                        if (OnTouchUpHandler != null) { OnTouchUpHandler(); }
                    }
                }
            }
#endif
        }

        private bool DoesHitButton(Touch touch)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            return Physics.Raycast(ray, out hit) && hit.transform == transform;
        }
    }
}