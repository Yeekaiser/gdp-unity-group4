using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    [SerializeField] private GameObject winpanel;
    [SerializeField] private GameObject losepanel;
    [SerializeField] private GameObject wintext;
    [SerializeField] private GameObject losetext;

    public GameObject Player;
    private SoundMeter sound;
    private float currentnoise;

    private FriendScript scenario;
    [SerializeField] private GameObject[] loseMessage;

    // Start is called before the first frame update
    void Start()
    {
        losepanel.SetActive(false);
        winpanel.SetActive(false);
        wintext.SetActive(false);
        losetext.SetActive(false);
        sound = GameObject.Find("Sound").GetComponent<SoundMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sound.currentNoise > 480 && Time.time > 3)
        {
            Lose();
        }
    }

    public void Win()
    {
        winpanel.SetActive(true);
        wintext.SetActive(true);

        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<JoystickMove>().enabled = false;
    }

    public void Lose()
    {
        losepanel.SetActive(true);
        losetext.SetActive(true);
        loseMessage[scenario.scenario].SetActive(true);

        Player.GetComponent<PlayerLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<JoystickMove>().enabled = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(0)
;    }
}
