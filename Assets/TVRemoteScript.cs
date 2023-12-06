using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVRemoteScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TVObj;
    [SerializeField]
    private TVScript TV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
                Debug.Log("Did Hit" + hit.collider.name);
                if (hit.collider.gameObject == TVObj && TV.tvCurrentVol >= 0)
                {
                    TV.tvCurrentVol -= 1 * Time.deltaTime;
                }
            }
        }
        
    
    }


}
