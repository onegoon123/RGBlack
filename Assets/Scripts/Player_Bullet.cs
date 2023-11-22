using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour {

    public float bulletSpeed;

    Transform transform;
    Transform tr_enmey;
    Collider2D collider2D;

	void Start () {
        transform = GetComponent<Transform>();
        transform.parent = null;
        tr_enmey = GameObject.Find("Enemy").GetComponent<Transform>();
        collider2D = GetComponent<Collider2D>();
	}
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, tr_enmey.position, bulletSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Enemy")) {
            GameObject.Find("Enemy").GetComponent<Enemy_Main>().Hit();
            Destroy(gameObject);
        }
    }
}
