using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private GameObject enemyExplosionPrefab;

    private float speed = 5.0f;

    //create handler for ui manager
    private UIManager uiManager;

    //reference to audio source for explosion
    [SerializeField]
     private AudioClip clip;

    // Use this for initialization
    void Start ()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      
        
	}
	
	// Update is called once per frame
	void Update () {

        //move down
        transform.Translate(Vector3.down * speed * Time.deltaTime);
             
		

        if (transform.position.y <-7)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX,7, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if (other.transform.parent !=null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            //count laser only as valid hit
            uiManager.UpdateScore();
            //Play explosion sound 
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);

            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                //by calling this we will subtract one life
                player.Damage();
            }

            //update if player hits ship
            uiManager.UpdateScore();
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            //Play explosion sound at main camera
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
            //this will destroy the ship
            Destroy(this.gameObject);

           
          
        }
    }
}
