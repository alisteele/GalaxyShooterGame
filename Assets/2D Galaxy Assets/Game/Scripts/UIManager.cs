using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //variable to hold sprites of images
    public Sprite[] lives;

    public Image livesImageDisplay;

    //variable to hold score
    public int score;
    //Adds to canvas in unity
    public Text scoreText;

    //reference for game manager
    public GameObject titleScreen;

    //Handle update of lives display
    public void UpdateLives(int currentLives)
    {
        Debug.Log("player lives: " + currentLives);
        livesImageDisplay.sprite = lives[currentLives];
    }

    //Update score method
    public void UpdateScore()
    {
        //update with 10
        score += 10;

        scoreText.text = "Score: " + score;
    }

    //For game manager class
    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    //for game manager class
    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        //reset score when game resets
        scoreText.text = "Score: ";

    }

}
