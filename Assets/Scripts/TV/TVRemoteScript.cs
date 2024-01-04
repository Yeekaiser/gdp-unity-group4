using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVRemoteScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TVObj;
    [SerializeField]
    private TVScript TV;
    [SerializeField] private Camera cam;
    public float remoteVolDownRate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == cam.transform)        //if the remote has been picked up by player
        {
            //decreases the volume per press if the ray hits the tv
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))    //uses raycast to check if pointing at the TV
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("Did Hit" + hit.collider.name);
                    if (hit.collider.gameObject == TVObj && TV.tvCurrentVol >= 0)
                    {
                        //Debug.Log("vol reduced");
                        TV.tvCurrentVol -= remoteVolDownRate;
                    }
                }
            }

            //increases the volume per press if the ray hits the tv
            if (Input.GetKeyDown(KeyCode.F))
            {

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))    //uses raycast to check if pointing at the TV
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //Debug.Log("Did Hit" + hit.collider.name);
                    if (hit.collider.gameObject == TVObj)
                    {
                        //Debug.Log("volume up");
                        TV.tvCurrentVol += remoteVolDownRate;
                    }
                }
            }
        }
    }


}
