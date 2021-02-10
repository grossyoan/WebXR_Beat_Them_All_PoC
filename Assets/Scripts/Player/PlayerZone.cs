using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    public Transform PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(PlayerCamera.position.x, 0, PlayerCamera.position.z);

    }

    public void RemovePoint(GameObject obj)  
    {
        Debug.Log("Lost a point");
        Destroy(obj);
    }
}
