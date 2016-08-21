using Assets.Scripts.controller.helper;
using Assets.Scripts.controller.player;
using UnityEngine;

namespace Assets.Scripts.controller
{
    public class MobileMenu : MonoBehaviour
    {

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
            _leftArrow.GetComponent<Toucher>().OnTouchDownHandler += PlayerController.Instance.TurnLeft;
            _leftArrow.GetComponent<Toucher>().OnTouchUpHandler += PlayerController.Instance.StopTurn;

            _rightArrow = Instantiate(RightArrowPrefab);
            _rightArrow.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _rightArrow.GetComponent<Toucher>().OnTouchDownHandler += PlayerController.Instance.TurnRight;
            _rightArrow.GetComponent<Toucher>().OnTouchUpHandler += PlayerController.Instance.StopTurn;

            _fireCannonButton = Instantiate(FireCannonButtonPrefab);
            _fireCannonButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _fireCannonButton.GetComponent<Toucher>().OnTouchDownHandler += PlayerController.Instance.FireCannon;

            _fireMachineGunButton = Instantiate(FireMachineGunButtonPrefab);
            _fireMachineGunButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _fireMachineGunButton.GetComponent<Toucher>().OnTouchDownHandler += PlayerController.Instance.FireMachineGun;
            _fireMachineGunButton.GetComponent<Toucher>().OnTouchUpHandler += PlayerController.Instance.StopFireMachineGun;

            Debug.Log("Show mobile controlls");
        }

        public void HideControlls()
        {
            _leftArrow.GetComponent<Toucher>().OnTouchDownHandler -= PlayerController.Instance.TurnLeft;
            _leftArrow.GetComponent<Toucher>().OnTouchUpHandler -= PlayerController.Instance.StopTurn;
            _rightArrow.GetComponent<Toucher>().OnTouchDownHandler -= PlayerController.Instance.TurnRight;
            _rightArrow.GetComponent<Toucher>().OnTouchUpHandler -= PlayerController.Instance.StopTurn;

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
