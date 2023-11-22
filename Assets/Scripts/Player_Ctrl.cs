using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Ctrl : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Shield;
    public GameObject hitbox;
    public GameObject trail;
    public SpriteRenderer hitBox;
    public Slider bar_HP;
    public Slider bar_SP;
    /*
    public int damage;
    public float fireRate;
    public int MaxHP;
    public float UseSP;
    public float skill_size;
    public float skill_time;
    */

    int HP;
    float SP = 0;
    float t_shoot;
    float t_skill;
    bool godTIme = false;

    Transform transform;
    Vector3 pos_before;
    Vector3 pos_start;

	void Start () {
        transform = GetComponent<Transform>();
        HP = GameManager.instance.MaxHP;
        SP = GameManager.instance.UseSP;
	}
	
	void Update () {
        Move();
        Shoot();
        Skill();
	}

    IEnumerator inputSkill() {
        t_skill = 0;
        while(t_skill <= 0.3) {
            t_skill += Time.deltaTime;
            yield return null;
        }
        t_skill = 0;
        yield return null;
    }

    void Move() {

        if (Input.GetMouseButtonDown(0))
        {
            pos_before = transform.position;
            pos_start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos_start.z = 0;

            if (t_skill > 0 && SP >= GameManager.instance.UseSP && HP > 0) {
                Instantiate(Shield, transform);
                SP = 0;
            }

            StartCoroutine(inputSkill());
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos_now = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos_now.z = 0;
            Vector3 pos_move = pos_before + pos_now - pos_start;

            Vector3 viewPos = Camera.main.WorldToViewportPoint(pos_move); //이동좌표를 뷰포트 좌표계로 변환해준다.
            viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
            viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
            
            transform.position = worldPos;
        }

        if(Input.GetKey(KeyCode.Z))
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime * 30);
        else if (Input.GetKey(KeyCode.X))
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime * 5);
        else
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized * Time.deltaTime * 8);
        if (Input.GetKey(KeyCode.C) && SP >= GameManager.instance.UseSP)
        {
            Instantiate(Shield, transform);
            SP = 0;
        }

        if (transform.position.x < -2.9) transform.position = new Vector3(-2.9f, transform.position.y, 0);
        if (transform.position.x > 2.9) transform.position = new Vector3(2.9f, transform.position.y, 0);
        if (transform.position.y < -4.7) transform.position = new Vector3(transform.position.x, -4.7f, 0);
        if (transform.position.y > 4.7) transform.position = new Vector3(transform.position.x, 4.7f, 0);
    }

    void Shoot() {
        t_shoot += Time.deltaTime;
        if (t_shoot >= GameManager.instance.fireRate) {
            Instantiate(Bullet, transform);
            t_shoot = 0;
        }
    }

    void Skill() {
        if (SP < GameManager.instance.UseSP)
            SP += Time.deltaTime;
        else if (SP > GameManager.instance.UseSP)
            SP = GameManager.instance.UseSP;
        bar_SP.value = SP / GameManager.instance.UseSP;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Bullet")) {
            if (godTIme == false) {
                HP--;
                bar_HP.value = (float)HP / GameManager.instance.MaxHP;
                StartCoroutine(HitAnim());

                if (HP <= 0)
                    StartCoroutine(death());
            }
        }
    }

    IEnumerator HitAnim()
    {
        godTIme = true;

        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * 2;
            hitBox.color = Color.green;
            yield return null;
        }

        t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime;
            hitBox.color = Color.Lerp(Color.green, Color.black, t);
            yield return null;
        }
        godTIme = false;
        yield return null;
    }

    IEnumerator death() {
        transform.localScale = new Vector3(0, 0, 0);
        Destroy(hitbox);
        Destroy(trail);
        float t = 0;
        while (t < 2f) {
            t_shoot = -10;
            t += Time.deltaTime;
            yield return null;
        }
        t = 1;
        while (t >= 0)
        {
            t -= Time.deltaTime * 0.5f;
            GameObject.Find("BGM").GetComponent<AudioSource>().volume = t;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }

}
