using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    [SerializeField] private GameObject winpanel;
    [SerializeField] private GameObject losepanel;

    public TMP_Text loseReasonText;

    public GameObject Player;
    private SoundMeter sound;
    private float currentnoise;

    // Start is called before the first frame update
    void Start()
    {
        losepanel.SetActive(false);
        winpanel.SetActive(false);
        sound = GameObject.Find("Sound").GetComponent<SoundMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (sound.currentNoise > 480 && Time.time > 3)
        //{
        //    //Lose();
        //}
    }

    public void Win()
    {
        winpanel.SetActive(true);

        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<JoystickMovement>().enabled = false;
    }

    public void Lose(string loseReason)
    {
        losepanel.SetActive(true);

        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerForward>().enabled = false;
        //Player.GetComponent<JoystickMovement>().enabled = false;

        loseReasonText.text = loseReason;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0)
;    }
}
