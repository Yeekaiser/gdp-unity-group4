using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    [SerializeField]
    private SoundMeter sound;

    public float tvMaxVol = 100f;
    public float tvVolUpRate = 5f;
    public float tvCurrentVol;
    public float tvVolUpDelaySeconds = 10f;

    public bool tvIsOn = false;

    public float interval = 0.5f;  // Set the interval in seconds
    private float lastTriggerTime;

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lastTriggerTime = Time.time;

        InvokeRepeating("TVVolUp", 0, tvVolUpDelaySeconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayTVSound();
    }
        

    void TVVolUp()
    {
        Debug.Log("TVVolUp called");
        if(tvCurrentVol < tvMaxVol)
        {
            tvCurrentVol += tvVolUpRate;
        }
    }

    void PlayTVSound()
    {

        if (Time.time - lastTriggerTime >= interval)
        {
            sound.currentNoise += tvCurrentVol;

            // Update lastTriggerTime to the current time
            lastTriggerTime = Time.time;
        }
        //Debug.Log(tvCurrentVol);
        
    }
}