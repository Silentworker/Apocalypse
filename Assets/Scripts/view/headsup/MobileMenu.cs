using Assets.Scripts.controller.player;
using Assets.Scripts.core.touch;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.view.mobile
{
    public class MobileMenu : MonoBehaviour
    {
        [Inject]
        IPlayerController playerController;

        public GameObject LeftArrowPrefab;
        public GameObject RightArrowPrefab;
        public GameObject FireCannonButtonPrefab;
        public GameObject FireMachineGunButtonPrefab;

        private GameObject _leftArrow;
        private GameObject _rightArrow;
        private GameObject _fireCannonButton;
        private GameObject _fireMachineGunButton;

        public void ShowControlls()
        {
            _leftArrow = Instantiate(LeftArrowPrefab);
            _leftArrow.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _leftArrow.GetComponent<Toucher>().OnTouchDownHandler += playerController.TurnLeft;
            _leftArrow.GetComponent<Toucher>().OnTouchUpHandler += playerController.StopTurn;

            _rightArrow = Instantiate(RightArrowPrefab);
            _rightArrow.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _rightArrow.GetComponent<Toucher>().OnTouchDownHandler += playerController.TurnRight;
            _rightArrow.GetComponent<Toucher>().OnTouchUpHandler += playerController.StopTurn;

            _fireCannonButton = Instantiate(FireCannonButtonPrefab);
            _fireCannonButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _fireCannonButton.GetComponent<Toucher>().OnTouchDownHandler += playerController.FireCannon;

            _fireMachineGunButton = Instantiate(FireMachineGunButtonPrefab);
            _fireMachineGunButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _fireMachineGunButton.GetComponent<Toucher>().OnTouchDownHandler += playerController.FireMachineGun;
            _fireMachineGunButton.GetComponent<Toucher>().OnTouchUpHandler += playerController.StopFireMachineGun;

            Debug.Log("Show mobile controlls");
        }

        public void HideControlls()
        {
            if (_leftArrow != null) _leftArrow.GetComponent<Toucher>().Clear();
            if (_rightArrow != null) _rightArrow.GetComponent<Toucher>().Clear();
            if (_fireCannonButton != null) _fireCannonButton.GetComponent<Toucher>().Clear();
            if (_fireMachineGunButton != null) _fireMachineGunButton.GetComponent<Toucher>().Clear();

            Destroy(_leftArrow);
            Destroy(_rightArrow);
            Destroy(_fireCannonButton);
            Destroy(_fireMachineGunButton);
        }

        void OnDestroy()
        {
            HideControlls();
        }
    }
}
