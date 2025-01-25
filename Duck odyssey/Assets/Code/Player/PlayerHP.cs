using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int PlayerHealth; // Player's health value
    public Goal Hight; // Visual timer value

    public float timeToWin = 300f; //Player must stay alive for this time to win
    private float sliderProgress = 0f; // Current surival time for player

    void Awake()
    {
        PlayerHealth = 2; // Starting player health
    }

    private void Update()
    {
        // If player's health is not 0, then run the time for the player to win
        if (PlayerHealth > 0)
        {
            sliderProgress += Time.deltaTime / timeToWin;

            sliderProgress = Mathf.Clamp(sliderProgress, 0f, 1f);

            Hight.SetProgress((int)(sliderProgress * Hight.slider.maxValue));
        }

        // If player's health is 0 or lower then bring up the game over state
        if (PlayerHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // If bath bomb hit's player, take away 1 health
        if (other.gameObject.CompareTag("BathBomb"))
        {
            PlayerHealth -= 1;
        }

        // If bath bomb hit's player, instantly kill the player
        if (other.gameObject.CompareTag("Water"))
        {
            PlayerHealth -= 2;
        }
    }
}
