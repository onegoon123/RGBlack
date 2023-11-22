using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sys_Remove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.transform.CompareTag("Bullet")) {
            Destroy(collider.gameObject);
        }
    }

}
