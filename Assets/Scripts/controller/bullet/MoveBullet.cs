using UnityEngine;

namespace Assets.Scripts.controller.bullet
{
    public class MoveBullet : MonoBehaviour
    {
        public float moveSpeed;
        void FixefUpdate()
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * moveSpeed);
        }
    }
}
