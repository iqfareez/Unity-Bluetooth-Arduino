using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject _player;

    private Rigidbody _playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = _player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0,1, _playerRigidBody.position.z - 10);
    }
}
