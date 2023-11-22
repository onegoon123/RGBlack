using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_target : MonoBehaviour
{

    public float speed;

    Transform transform;
    Transform target;
    Vector3 vector;

    void Start()
    {
        transform = GetComponent<Transform>();
        transform.parent = null;
        target = GameObject.Find("Player").GetComponent<Transform>();
        vector = target.position - transform.position;
    }

    void Update()
    {
        transform.Translate(vector * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
