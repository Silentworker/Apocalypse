using UnityEngine;

namespace Assets.Scripts.controller.boundary
{
    public class DestroyByBoundary : MonoBehaviour
    {
        void OnTriggerExit(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
