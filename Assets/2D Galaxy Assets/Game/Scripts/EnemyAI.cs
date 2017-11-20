using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


    private float speed = 5.0f;

    // Use this for initialization
    void Start () {
		
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
            //this will destroy the ship
            Destroy(this.gameObject);
        }
    }
}
