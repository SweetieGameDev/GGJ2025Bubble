using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class BeatSync : MonoBehaviour
{
    public AudioSource audioSource;
    public float bpm = 120f;
    public GameObject object1, object2, object3, object4;

    public float beatInterval;
    private int currentObjectIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Calculate interval between beats
        beatInterval = 60f / bpm;

        // Start syncing objects to the beat
        StartCoroutine(SyncObjectsToBeat());
    }

    IEnumerator SyncObjectsToBeat()
    {
        while (audioSource.isPlaying)
        {
            
            switch (currentObjectIndex)
            {
                case 0: ThrowObject(object1); break;
                case 1: ThrowObject(object2); break;
                case 2: ThrowObject(object3); break;
                case 3: ThrowObject(object4); break;   
            }
            // Cycle through objects
            currentObjectIndex = (currentObjectIndex + 1) % 4;

            // Wait for beat
            yield return new WaitForSeconds(beatInterval);
        }
    }

    void ThrowObject(GameObject obj)
    {
        if (obj != null) 
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>(); 
            if (rb != null) 
            {
                Vector3 randomForce = new Vector3(
                    UnityEngine.Random.Range(-5f, 5f),
                   UnityEngine.Random.Range(5f, 10f),
                    UnityEngine.Random.Range(-5f, 5f)
                );
                rb.AddForce(randomForce, ForceMode.Impulse); // Apply the force
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
