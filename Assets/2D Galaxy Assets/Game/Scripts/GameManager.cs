using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //when game first starts this will be true
    public bool gameOver = true;
    //create player variable
    public GameObject player;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    //if game over is true then if space is pressed game starts

    private void Update()
    {
        if (gameOver ==true)
        {
            //if space pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
              Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                //now game over is false
                gameOver = false;
                uiManager.HideTitleScreen();
            }
        }
    }
}
