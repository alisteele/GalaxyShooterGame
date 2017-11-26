using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //destroy the object with a time delay
        Destroy(this.gameObject, 4f);
	}
	
	
}
