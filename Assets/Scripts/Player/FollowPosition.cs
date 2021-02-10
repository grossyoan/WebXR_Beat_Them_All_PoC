using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    
    public Transform PlayerRigidbody;
    private Rigidbody currentRigidBody = null;
    // Start is called before the first frame update
    void Start()
    {
        currentRigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerRigidbody.position;
      //currentRigidBody.MovePosition(PlayerRigidbody.position);
    }
}
