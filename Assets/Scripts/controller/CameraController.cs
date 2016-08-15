using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerOffset;
    public Vector3 MenuPosition;

    private static CameraController _instance;

    private delegate void UpdateAction();
    private UpdateAction _updateHandler;
    private Transform _cameraTransform;
    private Transform _playerTransform;


    public static CameraController Instamce
    {
        get { return _instance ?? (_instance = FindObjectOfType(typeof(CameraController)) as CameraController); }
    }

    void Start()
    {
        _cameraTransform = gameObject.GetComponent<Transform>();
        _playerTransform = Player.GetComponent<Transform>();
    }

    void LastUpdate()
    {
        if (_updateHandler != null)
        {
            _updateHandler();
        }
    }

    public void followPlayer()
    {
        _updateHandler += FollowPlayerAction;
    }

    public static void FollowPlayer()
    {
        Instamce.followPlayer();
    }

    public void unfollowPlayer()
    {
        _updateHandler -= FollowPlayerAction;
    }

    public static void UnFollowPlayer()
    {
        Instamce.unfollowPlayer();
    }

    private void FollowPlayerAction()
    {
        _cameraTransform.position = _playerTransform.position + PlayerOffset;
    }
}
