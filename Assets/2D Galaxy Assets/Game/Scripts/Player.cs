using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Colon stands for inherit
public class Player : MonoBehaviour {


    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldBoostActive = false;
    //Live system
    public int lives = 3;

    //Setting laser variable
    [SerializeField]
    private GameObject laserPreFab;
    [SerializeField]
    private GameObject tripleShotPreFab;
    [SerializeField]
    private float fireRate = 0.25f;

    private float canFire = 0.0f;
 


    //Serializefield allows the variable beneath to be manipulated in Unity.
    [SerializeField]
    private float speed = 10.0f;
    
    //Both methods are part of the monobehaviour runtime
	// Use this for initialization
	private void Start () {
        //current position = new position. Player starts on left then is set to 0,0,0
        transform.position = new Vector3(0,0,0);
       
    }

    // Update is called once per frame
    //* time.deltatime slows down the ship
    private void Update()

    {
        Movement();

        //if space key is pressed we want to spawn an object at player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
      
        if (Time.time > canFire)
        {
            if (canTripleShot == true)
            {
                Instantiate(tripleShotPreFab, transform.position, Quaternion.identity);
            }
            else
            {
                //spawn laser
                Instantiate(laserPreFab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
         
            canFire = Time.time + fireRate;
        }
    }

private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive == true)
        {
            //Move left and right
            transform.Translate(Vector3.right * speed * 1.5f * horizontalInput * Time.deltaTime);
            //Move up and down
            transform.Translate(Vector3.up * speed * 1.5f * verticalInput * Time.deltaTime);
        }
        else
        {

        //Move left and right
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //Move up and down
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }


        //wrap ship so it can't go out of boundaries
        //up and down
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //left and right
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }


    public void Damage()
    {
        //subtract 1 life from player
        lives--;
        //if lives is < 1 then destroy the player
        if (lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
            {
                yield return new WaitForSeconds(5.0f);
                canTripleShot = false;
            }


    public void SpeedBoostPowerUpOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
     public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }


    public void ShieldBoostPowerUpOn()
    {
        isShieldBoostActive = true;
        StartCoroutine(ShieldBoostPowerDownRoutine());
    }

    public IEnumerator ShieldBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isShieldBoostActive = false;
    }
}

