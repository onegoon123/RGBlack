using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Shield : MonoBehaviour {

    Transform transform;
    Transform target;

    float size;
    float time;

	void Start () {
        transform = GetComponent<Transform>();
        transform.parent = null;
        target = GameObject.Find("Enemy").GetComponent<Transform>();
        size = GameManager.instance.skill_size;
        time = GameManager.instance.skill_time;
        StartCoroutine(shieldSize());
    }
	
    IEnumerator shieldSize() {
        float t = 0;
        while(t <= 1) {
            t += Time.deltaTime * 2f;
            transform.localScale = new Vector3(t * size, t * size, 1);
            yield return null;
        }

        t = 0;
        while (t <= time)
        {
            t += Time.deltaTime;
            transform.localScale = new Vector3(size, size, 1);
            yield return null;
        }

        t = 1;
        while (t >= 0)
        {
            t -= Time.deltaTime;
            transform.localScale = new Vector3(t * size, t * size, 1);
            yield return null;
        }
        Destroy(gameObject);
    }

	void Update () {
        if (GameManager.instance.skill_shoot == true)
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
    }
}
