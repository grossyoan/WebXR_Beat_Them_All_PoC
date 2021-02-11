using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


[System.Serializable]

public class RaycastHitEvent : UnityEvent<Vector3>
{

}

[System.Serializable]
public class InterractionUsable : UnityEvent<int>
{

}

public class TouchRayCast : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public LayerMask Navigable;
    public RaycastHitEvent OnRaycast;
    public LayerMask Interraction;
    public InterractionUsable usable;
    public GameObject[] bouttons;
    private int IndexList = 0;
    private bool CanSearch = false;
    private string InterractName;

    private Vector2 DownPos;

    public void OnPointerDown(PointerEventData data)
    {
        DownPos = data.position;
    }

    public void OnPointerUp(PointerEventData data)
    {
        float distance = Vector2.Distance(DownPos, data.position);

        if(distance < 2)
        {
            Ray ray = RectTransformUtility.ScreenPointToRay(Camera.main, data.position);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (ShouldRespond(hitInfo.collider.gameObject))
                {
                    //Debug.Log("Raycast Hit at " + hitInfo.point);
                    OnRaycast.Invoke(hitInfo.point);
                }

                if (ShouldInterract(hitInfo.collider.gameObject))
                {
                    CanSearch = true;
                    InterractName = hitInfo.collider.name;
                    
                }

            }
        }

        
    }

    bool ShouldRespond(GameObject g)
    {
        return ((Navigable & (1 << g.layer)) != 0);
    }

    bool ShouldInterract(GameObject c)
    {
        return ((Interraction & (1 << c.layer)) != 0);
    }


    void Update()
    {
        while (IndexList < bouttons.Length - 1 && bouttons[IndexList].name != InterractName)
        {
            IndexList += 1;
        }
        if (CanSearch)
        {
            CanSearch = false;
            usable.Invoke(IndexList);
            IndexList = 0;
        }
        
    }


}
