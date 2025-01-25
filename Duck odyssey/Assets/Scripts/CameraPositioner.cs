using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    public Transform FollowPoint;

   

    // Update is called once per frame
    void LateUpdate()
    {
        if (FollowPoint == null)
        {
            Debug.LogWarning("Target pbject is not assigned");
                return;
        }

        transform.LookAt(FollowPoint);

       /* Debug.DrawLine(transform.position, CameraPosition.position, Color.gray);

        Vector3 difference = CameraPosition.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(difference, Vector3.up);
        transform.rotation = rotation;*/
    }
}
