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

            _rightArrow = Instantiate(RightArrowPrefab);
            _rightArrow.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);

            _fireCannonButton = Instantiate(FireCannonButtonPrefab);
            _fireCannonButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);

            _fireMachineGunButton = Instantiate(FireMachineGunButtonPrefab);
            _fireMachineGunButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);

            _leftArrow.GetComponent<Clicker>().OnMouseDownHandler += PlayerController.Instance.TurnLeft;
            _leftArrow.GetComponent<Clicker>().OnMouseUpHandler += PlayerController.Instance.StopTurn;
            _rightArrow.GetComponent<Clicker>().OnMouseDownHandler += PlayerController.Instance.TurnRight;
            _rightArrow.GetComponent<Clicker>().OnMouseUpHandler += PlayerController.Instance.StopTurn;

            Debug.Log("Show mobile controlls");
        }

        public void HideControlls()
        {
            _leftArrow.GetComponent<Clicker>().OnMouseDownHandler -= PlayerController.Instance.TurnLeft;
            _leftArrow.GetComponent<Clicker>().OnMouseUpHandler -= PlayerController.Instance.StopTurn;
            _rightArrow.GetComponent<Clicker>().OnMouseDownHandler -= PlayerController.Instance.TurnRight;
            _rightArrow.GetComponent<Clicker>().OnMouseUpHandler -= PlayerController.Instance.StopTurn;

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
