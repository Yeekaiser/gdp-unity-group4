using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    [SerializeField] private GameObject winpanel;
    [SerializeField] private GameObject losepanel;
    [SerializeField] private GameObject wintext;
    [SerializeField] private GameObject losetext;
    private bool isGameOver = false;
    private SoundMeter sound;
    // Start is called before the first frame update
    void Start()
    {
        losepanel.SetActive(false);
        winpanel.SetActive(false);
        wintext.SetActive(false);
        losetext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (sound.currentNoise == 500)
        {
            isGameOver = true;
        }
        if (isGameOver == true)
        {
            losepanel.SetActive(true);
            losetext.SetActive(true);
        }
    }
}
