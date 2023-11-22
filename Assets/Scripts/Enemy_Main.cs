using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Enemy_Main : MonoBehaviour {

    float HP;

    public float MaxHP;
    public Slider slider;
    public SpriteRenderer hitBox;
    public GameObject clear;
    SpriteRenderer sprite;

    void Awake () {
        if (GameManager.instance.difficulty == 0)
            gameObject.GetComponent<Enemy_Pattern1_easy>().enabled = true;
        if (GameManager.instance.difficulty == 1)
            gameObject.GetComponent<Enemy_Pattern1>().enabled = true;
        if (GameManager.instance.difficulty == 2)
            gameObject.GetComponent<Enemy_Pattern1_hard>().enabled = true;
        if (GameManager.instance.difficulty == 3) {
            gameObject.GetComponent<Enemy_Pattern1_hell>().enabled = true;
            gameObject.GetComponent<Enemy_Pattern1_hell1>().enabled = true;
        }
    }

	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        MaxHP = 100 + (GameManager.instance.difficulty * GameManager.instance.difficulty * 100);
        HP = MaxHP;
        // 쉬움 100 보통 200 어려움 500 지옥 1000
	}
	
	void Update () {
		
	}

    public void Hit() {
        HP -= GameManager.instance.damage;
        slider.value = (float)HP / MaxHP;
        StartCoroutine(HitAnim());
        if (HP <= 0)
            StartCoroutine(death());
    }

    IEnumerator HitAnim() {
        float t = 0;
        while(t <= 1) {
            t += Time.deltaTime * 4;
            hitBox.color = Color.Lerp(Color.red, Color.black, t);
            yield return null;
        }
        yield return null;
    }

    IEnumerator death()
    {
        Instantiate(clear);
        gameObject.GetComponent<Enemy_Pattern1_easy>().enabled = false;
        gameObject.GetComponent<Enemy_Pattern1>().enabled = false;
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * 0.5f;
            hitBox.color = Color.black;
            sprite.color = Color.Lerp(Color.red, Color.black, t);
            yield return null;
        }
        transform.localScale = new Vector3(0, 0, 0);
        t = 1;
        while (t >= 0)
        {
            t -= Time.deltaTime * 0.5f;
            GameObject.Find("BGM").GetComponent<AudioSource>().volume = t;
            yield return null;
        }
        if (GameManager.instance.difficulty == 0)
            GameManager.instance.UP_point += 3;
        if (GameManager.instance.difficulty == 1)
            GameManager.instance.UP_point += 5;
        if (GameManager.instance.difficulty == 2)
            GameManager.instance.UP_point += 15;
        if (GameManager.instance.difficulty == 3)
            GameManager.instance.UP_point += 40;
        SceneManager.LoadSceneAsync(1);
    }
}
