using UnityEngine;

namespace Assets.Scripts.controller.camera
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        public GameObject Player;
        public Vector3 PlayerOffset;
        public Vector3 MenuPosition;

        public void FollowPlayer()
        {
            transform.position = Player.transform.position + PlayerOffset;
            Debug.Log("Follow player");
        }

        public void MoveToMenuPosition()
        {
            transform.position = MenuPosition;
            Debug.Log("Move to menu position");
        }
    }
}
