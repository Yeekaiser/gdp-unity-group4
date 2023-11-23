using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound
{
    public float currentNoise = 0;
}
public class SoundMeter : MonoBehaviour
{
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
        Sound a = new Sound();
        float currentNoise = a.currentNoise;
        rectangle.fillAmount = currentNoise / MAX_SOUND;
    }
}
