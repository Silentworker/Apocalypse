using UnityEngine;

namespace Assets.Scripts.controller.hatch
{
    public class HatchController : MonoBehaviour, IHatchController
    {
        public float DoorOpeningOffset;

        public GameObject DoorL;
        public GameObject DoorR;

        void Start()
        {
        }
    }
}
