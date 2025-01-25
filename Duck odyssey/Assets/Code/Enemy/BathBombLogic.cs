using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathBombLogic : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        // If bath bomb hit's player, destroy itself
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
