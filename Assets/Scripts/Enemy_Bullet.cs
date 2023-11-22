using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {

    public float speed;

    Transform transform;

	void Start () {
        transform = GetComponent<Transform>();
        transform.parent = null;
    }
	
	void Update () {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Shield")) {
            Destroy(gameObject);
        }
    }
}
