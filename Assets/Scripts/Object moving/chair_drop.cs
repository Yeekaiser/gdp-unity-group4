using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chair_drop : MonoBehaviour
{
    public AudioSource impactSound;
    public WinLose winLose;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y > 5)
        {
            winLose.Lose("Dropping the furniture made too much noise!");
            Debug.Log("Impact sound played!");
        }
    }
}