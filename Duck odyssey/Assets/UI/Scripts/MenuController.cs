using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject characterUI;
    public GameObject tutorialUI;
    public GameObject creditsUI;

    public void ShowCredits()
    {
        characterUI.SetActive(false);
        tutorialUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ShowTutorial() 
    {
        characterUI.SetActive(false);
        tutorialUI.SetActive(true);
        creditsUI.SetActive(false);
    }

    public void ShowCharacter()
    {
        characterUI.SetActive(true);
        tutorialUI.SetActive(false);
        creditsUI.SetActive(false);
    }
}
