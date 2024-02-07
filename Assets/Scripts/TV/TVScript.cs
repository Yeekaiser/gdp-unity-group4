using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TVScript : MonoBehaviour
{
    [SerializeField]
    private SoundMeter sound;

    public float tvMaxVol = 100f;
    public float tvVolUpRate = 5f;
    public float tvCurrentVol;
    public TextMeshProUGUI tvVolText;
    public WinLose winLose;
    //public float tvVolUpDelaySeconds = 10f;

    public bool tvIsOn = false;

    public float interval = 0.5f;  // Set the interval in seconds
    //private float lastTriggerTime;

    [HideInInspector]
    public float timePassed;
    [HideInInspector]
    public Animator anim;

    [SerializeField] private FriendScript scenario;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //lastTriggerTime = Time.time;

        //InvokeRepeating("TVVolUp", 0, tvVolUpDelaySeconds);
        StartCoroutine(TvVolUp());
    }

    private void Update()
    {
        
    }

    IEnumerator TvVolUp()
    {
        while (true)
        {
            if (tvIsOn == true)
            {
                //Debug.Log("tvIsOn");
                if(tvCurrentVol < tvMaxVol)
                {
                    //Debug.Log(tvCurrentVol + "is current vol");

                    tvCurrentVol += tvVolUpRate;
                    sound.MakeSound(tvCurrentVol);
                    tvVolText.text = "Volume: " + tvCurrentVol.ToString();
                }
                else
                {
                    if (tvCurrentVol >= tvMaxVol)
                        winLose.Lose("The TV Volme was too loud!");
                }
            }
            yield return new WaitForSeconds(interval);

        }
    }


    //IEnumerator PauseForSeconds(int seconds)
    //{

    //    // Pause for 5 seconds
    //    yield return new WaitForSeconds(seconds);

    //    scenario.nextScenario(scenario.scenario, 6);

    //}
}