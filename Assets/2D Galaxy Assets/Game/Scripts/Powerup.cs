﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerupID; //0=triple shot, 1= speed boost, 2=defence shiefl

    //powerup sound
    [SerializeField]
    private AudioClip clip;



    // Update is called once per frame
    void Update () {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //check if off screen and destroy object
        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided with: " + other.name);
        //tagged as player on unity
        //means if an enemy hits the powerup nothing will happen
        if (other.tag == "Player")
        {
            //access the player
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);

            if (player != null)
            {

                //turn the triple shot boolean to true
                if (powerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
               
                else if (powerupID == 1)
                {
                    //enable speed
                    player.SpeedBoostPowerUpOn();
                }
                else if (powerupID == 2)
                {
                    //enable shields
                    player.EnableShields();
                }

                
            }
        

            //destroy ourself
             Destroy(this.gameObject);
            
        }
       

    }
}
