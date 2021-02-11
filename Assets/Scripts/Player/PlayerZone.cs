using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    public Transform HandR;
    public Transform HandL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(( HandL.position.x + HandR.position.x)/2, 0, ( HandL.position.z + HandR.position.z)/2);
        //transform.position = (josh.position + mark.position)/2;
    }


    public void RemovePoint(GameObject obj)  
    {
        Debug.Log("Lost a point");
        Destroy(obj);
    }
}
