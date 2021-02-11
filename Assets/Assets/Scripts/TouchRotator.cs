using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;

public class TouchRotator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

	public GameObject[] Targets;
    public float Speed = 1.0f;
    private int Index = 0;
	public float timer = 1f;
    private float CountDown;
    public GameObject Audio;

    
    public GameObject Camera;
    public float[] AnimationsTimes;
    private float Timer;
    private int IndexAnim = 0;

    private float TimerAudio;
    private PostProcessVolume PostProcessAutomn;
    private PostProcessVolume PostProcessDepressed;
    public GameObject VolumeAutomn;
    public GameObject VolumeDepressed;
    public GameObject VolumeTurnAround;

    public GameObject Devoreur;
    


    void Start()
    {
        CountDown = 0;
        Timer = 0;
        TimerAudio = 0;
        PostProcessAutomn = VolumeAutomn.GetComponent<PostProcessVolume>();
        PostProcessDepressed = VolumeDepressed.GetComponent<PostProcessVolume>();
    }

	public void OnPointerDown(PointerEventData data)
	{
		CountDown = Time.time + timer;
        
        //Debug.Log("Delta MouseDown = " + Delta);
	}
	
	public void OnPointerUp(PointerEventData data)
	{   
        //Debug.Log("timer Up = " + timer);
        //Debug.Log("Time = " + Time.time);
		if(CountDown >= Time.time && TimerAudio <= Time.time)
        {

            

            //Debug.Log("Passe au suivant");
            if (Index <= Targets.Length - 1){
                if(Index + 1 == Targets.Length){
                    Debug.Log("Celui la marche");
                    Targets[Index].SetActive(false);
                    VolumeDepressed.SetActive(true);
                    VolumeAutomn.SetActive(true);
                    VolumeTurnAround.SetActive(false);
                    
                }

                else{
                    Debug.Log("Celui la aussi");
                    Targets[Index].SetActive(false);
                    VolumeDepressed.SetActive(true);
                    VolumeAutomn.SetActive(true);
                    VolumeTurnAround.SetActive(false);
                }
                

                UpdateTimer();

           

                Index += 1;
                //Debug.Log("Index = " +  Index);
                

            }
            PostProcessDepressed.weight += 0.33f;
            PostProcessAutomn.weight -= 0.33f;
            MoveCam(Camera);
        }
        
	}

	public void OnDrag(PointerEventData data)
	{
        if(Index < Targets.Length - 1)
        {
            Targets[Index].transform.Rotate(
                0, //x,
                -data.delta.x * Speed, //y,
                0,  //z
                Space.Self
            );

            Targets[Index].transform.Rotate(
                data.delta.y * Speed, //x,
                0, //y,
                0,  //z
                Space.World
            );
        }
            
        
        
    }	


    public void MoveCam(GameObject Camera){
        Animator animCam = Camera.GetComponent<Animator>();
        bool Images = animCam.GetBool("AllImageOk");
        bool Talkie = animCam.GetBool("TalkieOk");
        bool Journal = animCam.GetBool("JournalOk");
        if (!Images){
            animCam.SetBool("AllImageOk", true);
        }
        if (Images && !Talkie){
            animCam.SetBool("TalkieOk", true);
        }
        if (Talkie && !Journal){
            animCam.SetBool("JournalOk", true);
        }
    }	


    void Update(){
        if (Timer != 0 && Timer <= Time.time){
            
            Targets[Index].SetActive(true);
            VolumeDepressed.SetActive(false);
            VolumeAutomn.SetActive(false);
            VolumeTurnAround.SetActive(true);

            Timer = 0;
            if (Index == 1)
            {
                Audio.SetActive(true);
                Devoreur.SetActive(true);
                
                TimerAudio = Time.time + 15;
            }
        }
        


    }
    

    void UpdateTimer(){

        if (IndexAnim < AnimationsTimes.Length){
            Timer = AnimationsTimes[IndexAnim] + Time.time;
            IndexAnim += 1;
        }
        
    }
}
