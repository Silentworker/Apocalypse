using System;
using Assets.Scripts.core;
using Assets.Scripts.models;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public class HatchController : MonoBehaviour
    {
        public float DoorOpeningOffset;

        public GameObject DoorL;
        public GameObject DoorR;
        public GameObject TourelleBody;

        private static HatchController _instance;

        public static HatchController Instamce
        {
            get { return _instance ?? (_instance = FindObjectOfType(typeof(HatchController)) as HatchController); }
        }

        void Start()
        {
        }

        void Update()
        {
        }

    }
}
