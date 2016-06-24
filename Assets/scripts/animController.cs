using UnityEngine;
using System.Collections;

public class animController : MonoBehaviour
{

    private Animator anim;


    void Start()
    {
        

        anim = GetComponent<Animator>();




    }


    void Update()
    {

       
        // als h wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            Debug.Log("testbutton");
            
            //zet de die animation bool op true
            anim.SetBool("die", true);

        }
        else
        {
            //zet de die animation bool op false
            anim.SetBool("die", false);
        }
    }
}

