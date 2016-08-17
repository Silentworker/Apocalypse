using UnityEngine;

namespace Assets.Scripts.controller
{
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _instance;

        public static PlayerController Instance
        {
            get { return _instance ?? (_instance = FindObjectOfType(typeof(PlayerController)) as PlayerController); }
        }

        public float TurnSpeed;

        private delegate void UpdateHandler();

        private UpdateHandler _updateHandler;

        void Update()
        {
            if (_updateHandler != null)
            {
                _updateHandler();
            }
        }

        // region: Controlls
        private void controlsHandler()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.forward, -TurnSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(Vector3.forward, TurnSpeed * Time.deltaTime);
        }

        public void AllowControlls()
        {
            _updateHandler += controlsHandler;
        }

        public void ForbidControlls()
        {
            _updateHandler -= controlsHandler;
        }
        // end region: Controlls
    }
}
