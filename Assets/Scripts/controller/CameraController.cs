using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerOffset;
    public Vector3 MenuPosition;

    private delegate void UpdateAction();
    private UpdateAction _updateHandler;
    private Transform _playerTransform;
    private Transform _cameraTransform;

    private static CameraController _instance;

    public static CameraController Instamce
    {
        get { return _instance ?? (_instance = FindObjectOfType(typeof(CameraController)) as CameraController); }
    }

    void LastUpdate()
    {
        if (_updateHandler != null)
        {
            _updateHandler();
        }
    }
    // region: follow player
    public void followPlayer()
    {
        Debug.Log("Follow player");
        _updateHandler += FollowPlayerAction;
    }

    public static void FollowPlayer()
    {
        Instamce.followPlayer();
    }

    private void FollowPlayerAction()
    {
        CameraTransform.position = PlayerTransform.position + PlayerOffset;
    }
    // end region: follow player

    // region: unfollow player
    public void unfollowPlayer()
    {
        if (_updateHandler != null)
        {
            _updateHandler -= FollowPlayerAction;
        }
    }

    public static void UnFollowPlayer()
    {
        Instamce.unfollowPlayer();
    }
    // end region: unfollow player

    // region: move to menu position
    public void moveToMenuPosition()
    {
        CameraTransform.position = MenuPosition;
    }

    public static void MoveToMenuPosition()
    {
        Instamce.moveToMenuPosition();
    }
    // end region: move to menu position

    private Transform CameraTransform
    {
        get { return _cameraTransform ?? (_cameraTransform = gameObject.GetComponent<Transform>()); }
    }

    private Transform PlayerTransform
    {
        get { return _playerTransform ?? (_playerTransform = Player.GetComponent<Transform>()); }
    }
}
