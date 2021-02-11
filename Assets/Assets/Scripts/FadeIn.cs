using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public GameObject Panel;
    private Animator Fade;
    public GameObject Sound;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Fade = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Fade.GetCurrentAnimatorStateInfo(0).IsName("PanelIdle"))
        {


            Sound.SetActive(true);
            
            if (Time.time >= 5.0f)
            {
                gameObject.SetActive(false);
                Panel.SetActive(true);
            }

        }
        
    }
}
