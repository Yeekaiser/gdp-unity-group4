using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float timePassed;
    public float doorOpenedTime;
    public float doorOpenDelay = 15f;

    public bool doorIsOpen;
    [HideInInspector]
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("DoorOpen", 0f, doorOpenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoorOpen()
    {
        if (!doorIsOpen)
        {
        anim.SetTrigger("doorOpen");
        doorIsOpen = true;
        }
        else
        {
            //set noise levels up
            //noiseScript.noiseLevel += 10f;
            anim.SetTrigger("doorClose");
            doorIsOpen= false;
        }
        
    }
}
