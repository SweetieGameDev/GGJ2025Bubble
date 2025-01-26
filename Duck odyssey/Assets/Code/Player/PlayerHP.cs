using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int PlayerHealth; // Player's health value
    public bool iFrames; // Can the player take damage
    public Goal Hight; // Visual timer value

    public End State;

    public float timeToWin = 120f; //Player must stay alive for this time to win
    private float sliderProgress = 0f; // Current surival time for player

    private Rigidbody DuckRB;

    void Awake()
    {
        timeToWin = 120f;
        PlayerHealth = 2; // Starting player health
        iFrames = false;

        DuckRB = GetComponent<Rigidbody>();

        DuckRB.useGravity = false; // Prevents Player from falling

        StartCoroutine(FindFirstObjectByType<SpawnObjects>().SpawnPrefabs());
        StartCoroutine(FindFirstObjectByType<SpawnBubbles>().SpawnPrefabs());
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

            DuckRB.useGravity = true;  // Dead Player falls into water

            State.LoseState();
        }


        // Check if sliderProgress matches timetowin
        if (sliderProgress >= 1f)
        {
            Debug.Log("Player Wins!");
            State.WinState();
        }

    }

    // Player is Invincible to all damage apart from water to 5 seconds
    private IEnumerator InvincibleTime()
    {
        iFrames = true;

        yield return new WaitForSeconds(5);

        iFrames = false;

        StopCoroutine(InvincibleTime());

    }

    public void OnTriggerEnter(Collider other)
    {
        // If bath bomb hit's player, take away 1 health
        if (other.gameObject.CompareTag("BathBomb"))
        {
            // When damage is taken start Invincible Frames
            if (iFrames == false)
            {
                StartCoroutine(InvincibleTime());
                PlayerHealth -= 1;
            }
        }

        // If bubbles touch player, restore their health
        if (other.gameObject.CompareTag("Bubbles"))
        {
            PlayerHealth = 2;
        }

        // If bath bomb hit's player, instantly kill the player
        if (other.gameObject.CompareTag("Water"))
        {
            PlayerHealth -= 2;
        }
    }
}
