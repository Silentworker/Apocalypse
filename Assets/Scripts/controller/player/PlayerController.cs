﻿using System;
using UnityEngine;

namespace Assets.Scripts.controller.player
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public GameObject MainCameraBase;
        public float TurnSpeed;

        private delegate void UpdateHandler();

        private UpdateHandler _updateHandler;
        private Boolean _turnLeft;
        private Boolean _turnRight;

        void Update()
        {
            if (MainCameraBase.transform.rotation != transform.rotation)
            {
                MainCameraBase.transform.rotation = Quaternion.Slerp(MainCameraBase.transform.rotation,
                    transform.rotation, 2 * Time.deltaTime);
            }
        }

        void FixedUpdate()
        {
            if (_updateHandler != null)
            {
                _updateHandler();
            }
        }

        private void controlsHandler()
        {
            if (_turnLeft)
            {
                transform.Rotate(Vector3.up, -TurnSpeed * Time.fixedDeltaTime);
            }

            if (_turnRight)
            {
                transform.Rotate(Vector3.up, TurnSpeed * Time.fixedDeltaTime);
            }
        }

        public void AllowPlayerControll()
        {
            _updateHandler += controlsHandler;
        }

        public void ForbidPlayerControll()
        {
            _updateHandler -= controlsHandler;
        }

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
            GetComponent<Gunner>().StopFireMachineGun();
        }

        public void FireCannon()
        {
            GetComponent<Gunner>().FireCannon();
        }
    }
}
