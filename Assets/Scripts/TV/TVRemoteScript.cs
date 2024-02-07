using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVRemoteScript : MonoBehaviour
{
    
    [SerializeField] private GameObject TVObj;
    [SerializeField] private GameObject TVScreen;

    [SerializeField] private TVScript TV;
    //[SerializeField] private Camera cam;
    [SerializeField] private Transform holding;
    
    public float remoteVolDownRate = 5f;

    public GameObject volUI;
    //public GameObject volUp;
    //public GameObject volDown;
    public GameObject pointer;
    public FriendScript scenario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == holding)
        {
            volUI.SetActive(true);
            //volUp.SetActive(true);
            //volDown.SetActive(true);

            TVScreen.SetActive(true);
            pointer.SetActive(true);
            transform.rotation = Quaternion.identity;

            //TV.enabled = true;
            TV.tvIsOn = true;

            if(TV.tvIsOn == false)
            {
                StartCoroutine(NextScene());
            }

        }
        if (transform.parent == null)
        {
            volUI.SetActive(false);
            //volUp.SetActive(false);
            //volDown.SetActive(false);

            TVScreen.SetActive(false);
            pointer.SetActive(false);

            //TV.enabled = false;
            TV.tvIsOn = false;
        }



        //if (transform.parent == cam.transform)        //if the remote has been picked up by player
        //{
        //    TVScreen.SetActive(true);
        //    //if pickedup - show vol up/down

        //    //decreases the volume per press if the ray hits the tv
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))    //uses raycast to check if pointing at the TV
        //        {
        //            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //            //Debug.Log("Did Hit" + hit.collider.name);
        //            if (hit.collider.gameObject == TVObj && TV.tvCurrentVol >= 0)
        //            {
        //                //Debug.Log("vol reduced");
        //                TV.tvCurrentVol -= remoteVolDownRate;
        //                //change text on screen koi 
        //            }
        //        }
        //    }

        //    //increases the volume per press if the ray hits the tv
        //    if (Input.GetKeyDown(KeyCode.F))
        //    {

        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))    //uses raycast to check if pointing at the TV
        //        {
        //            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //            //Debug.Log("Did Hit" + hit.collider.name);
        //            if (hit.collider.gameObject == TVObj)
        //            {
        //                //Debug.Log("volume up");
        //                TV.tvCurrentVol += remoteVolDownRate;
        //                //change text on screen koi
        //            }
        //        }
        //    }
        //}
    }

    public void VolDown()
    {
        if (transform.parent == holding.transform) // If the remote has been picked up by the player
        {
            if (TV.tvCurrentVol > 0)
            {
                TV.tvCurrentVol -= remoteVolDownRate;
            }
            else
            {
                TV.tvCurrentVol = 0; // Prevents the volume from going below 0
            }
            TVScreen.SetActive(true); // Assuming you want to show the TV screen whenever volume is adjusted

            StartCoroutine(NextScene());
        }
    }

    public void VolUp()
    {
        if (transform.parent == holding.transform) // If the remote has been picked up by the player
        {
            TV.tvCurrentVol += remoteVolDownRate;
            TVScreen.SetActive(true); // Assuming you want to show the TV screen whenever volume is adjusted
                                      
        }
    }

    IEnumerator NextScene()
    {
        Debug.LogWarning("nextscene called");
        yield return new WaitForSeconds(10);
        scenario.nextScenario(scenario.scenario, 6);
    }
}
