using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    [SerializeField]
    private SoundMeter sound;

    public float tvMaxVol = 5f;  //koi edit this thx
    public float tvVolUpRate = 1f;
    public float tvCurrentVol;
    public float tvVolUpDelaySeconds = 10f;

    private float tvSpikeVol = 100f;   //koi edit this thx
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
    void Update()
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
        else
        {
            TVVolSpike();
        }
    }

    void TVVolSpike()
    {
        tvCurrentVol += tvSpikeVol;
    }

    void PlayTVSound()
    {

        if (Time.time - lastTriggerTime >= interval)
        {
            sound.currentNoise += tvCurrentVol;

            // Update lastTriggerTime to the current time
            lastTriggerTime = Time.time;
        }
        Debug.Log(tvCurrentVol);
        
    }
}