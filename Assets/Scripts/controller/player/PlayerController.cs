using System;
using UnityEngine;

namespace Assets.Scripts.controller.player
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
        private Boolean _turnLeft;
        private Boolean _turnRight;

        void FixedUpdate()
        {
            if (_updateHandler != null)
            {
                _updateHandler();
            }
        }

        // region: Controlls
        private void controlsHandler()
        {
            if (_turnLeft)
            {
                transform.Rotate(Vector3.forward, -TurnSpeed * Time.fixedDeltaTime);
            }

            if (_turnRight)
            {
                transform.Rotate(Vector3.forward, TurnSpeed * Time.fixedDeltaTime);
            }
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

        public void TurnLeft()
        {
            _turnLeft = true;
            _turnRight = false;
        }

        public void TurnRight()
        {
            _turnRight = true;
            _turnLeft = false;
        }

        public void StopTurn()
        {
            _turnRight = false;
            _turnLeft = false;
        }

        public void FireMachineGun()
        {
            GetComponent<Gunner>().FireMachineGun();
        }

        public void StopFireMachineGun()
        {
            GetComponent<Gunner>().StopFireMAchineGun();
        }

        public void FireCannon()
        {
            GetComponent<Gunner>().FireCannon();
        }
    }
}
