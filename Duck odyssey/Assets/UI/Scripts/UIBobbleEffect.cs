using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UWEGames.Examples
{
    public class UIBobbleEffect : MonoBehaviour
    {
        [SerializeField] private float positionOffset = 2;
        [SerializeField] private float bobbleSpeed = 5;

        private float originalY;

        // Start is called before the first frame update
        void Start()
        {
            originalY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {

            transform.position = new Vector3(transform.position.x,
                originalY + (float)Mathf.Sin(Time.time * bobbleSpeed) * positionOffset,
                transform.position.z);


        }
    }

}