using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OuverturePorte : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    public GameObject Porte;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = Porte.GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData data){

    }

    public void OnPointerUp(PointerEventData data){

        anim.SetBool("CanOpen", true);

    }

    public void OnDrag(PointerEventData data){

    }
}
