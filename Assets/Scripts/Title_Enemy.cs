using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Enemy : MonoBehaviour {

    Transform transform;

	void Start () {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector4(0, 0, -50, 0) * Time.deltaTime);
	}
}
