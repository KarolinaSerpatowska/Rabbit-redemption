using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    
    public float ttl = 100;
	void Start () {
	}
	
	void FixedUpdate () {
        ttl -= Time.fixedDeltaTime;
        if(ttl < 0)
        {
            Destroy(gameObject);
        }

	}

}
