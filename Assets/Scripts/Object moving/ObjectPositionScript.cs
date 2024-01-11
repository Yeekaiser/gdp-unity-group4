using UnityEngine;

public class ObjectPositionScript : MonoBehaviour
{
    public Transform startingPosition;
    public Transform targetPosition;
    private AudioSource audioSource; // Reference to the AudioSource component

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
            Debug.Log("Object entered the target area: " + gameObject.name);

            // Play the sound when the object reaches the target area
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Additional logic when the object reaches the target
        }
    }
}
