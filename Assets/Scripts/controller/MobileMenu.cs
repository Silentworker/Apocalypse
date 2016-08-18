using Assets.Scripts.controller.helper;
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

            Debug.Log("Show mobile controlls");
        }

        public void HideControlls()
        {
            Destroy(_leftArrow);
            Destroy(_rightArrow);
            Destroy(_fireCannonButton);
            Destroy(_fireMachineGunButton);
        }

        public Clicker.ClickHandler LeftArrowHandler
        {
            get { return _leftArrow.GetComponent<Clicker>().OnClickHandler; }
        }

        public Clicker.ClickHandler RightAHandler
        {
            get { return _rightArrow.GetComponent<Clicker>().OnClickHandler; }
        }

        public Clicker.ClickHandler FireCannonHandler
        {
            get { return _fireCannonButton.GetComponent<Clicker>().OnClickHandler; }
        }

        public Clicker.ClickHandler FireMachineGinHandler
        {
            get { return _fireMachineGunButton.GetComponent<Clicker>().OnClickHandler; }
        }

    }
}
