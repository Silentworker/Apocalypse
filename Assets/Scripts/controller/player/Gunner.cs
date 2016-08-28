using UnityEngine;

namespace Assets.Scripts.controller.player
{
    public class Gunner : MonoBehaviour
    {
        public GameObject MachineGunL;
        public GameObject MachineGunR;
        public GameObject MachineGunShootPointL;
        public GameObject MachineGunShootPointR;
        public GameObject MachineGunBulletPrefab;
        public float MachineGunTurnSpeed;
        public float MachineGunShotDelay;

        public GameObject MainGun;

        private delegate void UpdateAction();
        private UpdateAction _updateAction;

        private float _shootTime = 0;

        void FixedUpdate()
        {
            if (_updateAction != null)
            {
                _updateAction();
            }
        }

        public void FireMachineGun()
        {
            _updateAction += RotateMachineGuns;
            _updateAction += CreateMachineGunBullets;
            GetComponent<AudioSource>().Play();
        }

        public void StopFireMachineGun()
        {
            _updateAction -= RotateMachineGuns;
            _updateAction -= CreateMachineGunBullets;
            GetComponent<AudioSource>().Stop();
        }

        private void RotateMachineGuns()
        {
            MachineGunL.transform.Rotate(Vector3.forward, MachineGunTurnSpeed * Time.fixedDeltaTime);
            MachineGunR.transform.Rotate(Vector3.forward, -MachineGunTurnSpeed * Time.fixedDeltaTime);
        }

        private void CreateMachineGunBullets()
        {
            _shootTime += Time.fixedDeltaTime;
            if (_shootTime > MachineGunShotDelay)
            {
                _shootTime = 0;
                Instantiate(MachineGunBulletPrefab, MachineGunShootPointL.transform.position,
                    MachineGunShootPointL.transform.rotation);
                Instantiate(MachineGunBulletPrefab, MachineGunShootPointR.transform.position,
                    MachineGunShootPointL.transform.rotation);
            }
        }

        public void FireCannon()
        {
            MainGun.GetComponent<AudioSource>().Play();
            
        }
    }
}
