using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundMeter : MonoBehaviour
{
    public float currentNoise = 0;
    private Image rectangle;
    private const float MAX_SOUND = 100f;
    public float sound = MAX_SOUND;
    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<Image>();
        InvokeRepeating("decreaseSound", 1.0f, 1.0f);
    }
   
    // Update is called once per frame
    void Update()
    {
        rectangle.fillAmount = currentNoise / MAX_SOUND;
    }
    void decreaseSound()
    {
        if (currentNoise > 0)
        {
            currentNoise -= 0.5f;
        }
    }

}
