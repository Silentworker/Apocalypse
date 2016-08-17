using UnityEngine;

namespace Assets.Scripts.controller
{
    public class HatchController : MonoBehaviour
    {
        private static HatchController _instance;

        public static HatchController Instance
        {
            get { return _instance ?? (_instance = FindObjectOfType(typeof(HatchController)) as HatchController); }
        }

        public float DoorOpeningOffset;

        public GameObject DoorL;
        public GameObject DoorR;
        public GameObject TourelleBody;

        void Start()
        {
        }
    }
}
