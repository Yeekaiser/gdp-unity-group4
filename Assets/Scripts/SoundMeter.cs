using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundMeter : MonoBehaviour
{
    private Image rectangle;
    private const float MAX_SOUND = 100f;
    public float sound = MAX_SOUND;
    public float currentNoise;
    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        rectangle.fillAmount = sound / MAX_SOUND;
    }
}
