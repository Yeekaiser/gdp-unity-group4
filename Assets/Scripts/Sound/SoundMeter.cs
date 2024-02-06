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
    }
   
    // Update is called once per frame
    void Update()
    {
        float fillAmount = Mathf.Clamp01(currentNoise / MAX_SOUND);
        rectangle.fillAmount = fillAmount;
        //rectangle.fillAmount = currentNoise / MAX_SOUND;
        if (currentNoise > 0)
        {
            currentNoise -= 3f;
            if (currentNoise < 0)
                currentNoise = 0;
        }
        
    }

    public void MakeSound(float noiseMade)
    {
        currentNoise += noiseMade;
        if (currentNoise > 500f)
            currentNoise = 500f;
    }
}
