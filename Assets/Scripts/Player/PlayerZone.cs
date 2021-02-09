using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RemovePoint(GameObject obj)  
    {
        Debug.Log("Lost a point");
        Destroy(obj);
    }
}
