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

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        Debug.Log(tvCurrentVol);
        sound.sound += tvCurrentVol;
    }
}