using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private static CameraController _instance;

    public static CameraController Instance
    {
        get { return _instance ?? (_instance = FindObjectOfType(typeof(CameraController)) as CameraController); }
    }

    public GameObject Player;
    public Vector3 PlayerOffset;
    public Vector3 MenuPosition;

    public void FollowPlayer()
    {
        Debug.Log("Follow player");
        transform.position = Player.transform.position + PlayerOffset;
    }

    public void MoveToMenuPosition()
    {
        transform.position = MenuPosition;
    }
}
