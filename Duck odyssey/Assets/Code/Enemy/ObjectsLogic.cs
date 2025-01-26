using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsLogic : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        // If any object hit's player, destroy itself
        if (other.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }
    }
}
