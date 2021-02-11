using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnFirst : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject Photo;
    private float Timer;
    public GameObject VolumeAutomn;
    public GameObject VolumeDepressed;
    public GameObject VolumeTurnAround;
    public GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer != 0){
            if(Timer<=Time.time){
                Photo.SetActive(true);
                GetComponent<SpawnFirst>().enabled = false;
                Sound.SetActive(true);
                VolumeAutomn.SetActive(false);
                VolumeDepressed.SetActive(false);
                VolumeTurnAround.SetActive(true);
            }
            
        }

    }

    public void OnPointerDown(PointerEventData data){

    }

    public void OnPointerUp(PointerEventData data){

        SetTimer();

    }

    public void OnDrag(PointerEventData data){

    }

    void SetTimer(){
            Timer = Time.time + 7.0f;
        
    }
}
