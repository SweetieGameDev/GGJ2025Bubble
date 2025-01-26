using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UWEGames.Examples
{
    public class RandomisedSFXPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] sfxClips;

        private AudioSource source;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            source.volume = 0.25f;
            source.pitch = 0.8f;
        }

        public void PlaySFX()
        {
            int index = Random.Range(0, sfxClips.Length);
            source.PlayOneShot(sfxClips[index]);
        }
    }

}