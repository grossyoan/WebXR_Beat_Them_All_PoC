using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementCameraPorte : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Camera;
    private Animator anim;
    private bool PivotPorte;
    private Animator Porte;
    public GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        anim = Camera.GetComponent<Animator>();
        Porte = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        PivotPorte = GetComponent<Animator>().GetBool("CanOpen");
        if(PivotPorte && Porte.GetCurrentAnimatorStateInfo(0).IsName("PorteAnimation")){
            Sound.SetActive(true);
            anim.SetBool("PorteOuverte", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("CameraPorte")){
                Panel.GetComponent<OuverturePorte>().enabled = false;
                Panel.GetComponent<TouchRotator>().enabled = true;
                
            }
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("CameraPhoto")){
                Porte.SetBool("Close", true);
            }
        }
        
    }
}
