using UnityEngine;

public class ObjectPositionScript : MonoBehaviour
{
    public Transform startingPosition;
    public Transform targetPosition;
    private AudioSource audioSource; // Reference to the AudioSource component

    [SerializeField] private FriendScript scenario;

    bool inTarget = false;
    void Start()
    {
        if (startingPosition == null)
        {
            Debug.LogError("Starting position is not assigned in " + gameObject.name);
        }

        if (targetPosition == null)
        {
            Debug.LogError("Target position is not assigned in " + gameObject.name);
        }

        // Get the AudioSource component attached to this game object
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not attached to " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartingArea"))
        {
            Debug.Log("Object entered the starting area: " + gameObject.name);
        }

        if (other.CompareTag("TargetArea"))
        {
            if (inTarget == false)
            {
                if (scenario.scenario == 4)
                    scenario.scenario = 5;

                Debug.Log("Object entered the target area: " + gameObject.name);

                // Play the sound when the object reaches the target area
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                }

                inTarget = true;
                // Additional logic when the object reaches the target
            }
            else
            {
                inTarget = false;
            }
        }
    }
}
