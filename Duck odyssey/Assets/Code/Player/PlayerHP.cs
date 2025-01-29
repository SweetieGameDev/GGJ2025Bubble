using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHP : MonoBehaviour
{
    public int PlayerHealth; // Player's health value
    public float iFrameTime; // Time to take no damage
    public bool iFrames; // Can the player take damage
    public Goal Hight; // Visual timer value

    public GameObject PlayerInfoUI;

    public TextMeshProUGUI bubbleText; // Tells player how many lives they have

    public TextMeshProUGUI warningText; // Tells player to preform action to avoid game over

    public End State;

    private bool EndThreshold;

    public float timeToWin = 120f; //Player must stay alive for this time to win
    private float sliderProgress = 0f; // Current surival time for player

    private Rigidbody DuckRB;

    public GameObject bubble;

    void Awake()
    {
        timeToWin = 120f;
        PlayerHealth = 3; // Starting player health
        iFrameTime = 1.5f; // Default time to take no damage
        iFrames = false;

        PlayerInfoUI.SetActive(true);

        bubbleText.text = "Bubbles: " + PlayerHealth.ToString();
        warningText.text = "";

        DuckRB = GetComponent<Rigidbody>();

        DuckRB.useGravity = false; // Prevents Player from falling

        EndThreshold = false; // Used to prevent unwanted repeating of certain functions in update

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
        if (PlayerHealth <= 0 && EndThreshold != true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            EndThreshold = true;

            DuckRB.useGravity = true;  // Dead Player falls into water

            PlayerInfoUI.SetActive(false);

            State.LoseState();
        }


        // Check if sliderProgress matches timetowin
        if (sliderProgress >= 1f && EndThreshold != true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            EndThreshold = true;

            State.WinState();
        }

    }

    // Player is Invincible to all damage apart from water to 5 seconds
    private IEnumerator InvincibleTime()
    {
        iFrames = true;

        yield return new WaitForSeconds(iFrameTime);

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
                bubbleText.text = "Bubbles: " + PlayerHealth.ToString();
                warningText.text = "Enter new bubble now!";

                bubble.SetActive(false);
                DuckRB.useGravity = true;
            }
        }

        // If bubbles touch player, restore their health
        if (other.gameObject.CompareTag("Bubbles"))
        {
            PlayerHealth = 3;
            bubbleText.text = "Bubbles: " + PlayerHealth.ToString();
        }

        // If bath bomb hit's player, instantly kill the player
        if (other.gameObject.CompareTag("Water"))
        {
            PlayerHealth -= 2;
        }
    }
}
