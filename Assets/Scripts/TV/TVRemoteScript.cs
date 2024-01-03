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
                Debug.Log("volume down");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit" + hit.collider.name);
                    if (hit.collider.gameObject == TVObj && TV.tvCurrentVol >= 0)
                    {
                        TV.tvCurrentVol -= remoteVolDownRate;
                    }
                }
            }

            //increases the volume per press if the ray hits the tv
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("volume up");

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit" + hit.collider.name);
                    if (hit.collider.gameObject == TVObj && TV.tvCurrentVol >= 0)
                    {
                        TV.tvCurrentVol += remoteVolDownRate;
                    }
                }
            }
        }
    }


}
