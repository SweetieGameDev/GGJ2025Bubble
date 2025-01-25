using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject characterUI;
    public GameObject creditsUI;

    public void ShowCredits() 
    {
        characterUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ShowCharacter()
    {
        characterUI.SetActive(true);
        creditsUI.SetActive(false);
    }
}
