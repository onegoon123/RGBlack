using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Pattern1_hard : MonoBehaviour
{

    float t_pattern = 0;
    float t_shoot = 0;
    float t_corutine = 0;
    float fireRate;
    int random;
    int shoot = 0;

    Transform transform;
    Quaternion quaternion;

    public GameObject bullet;
    public GameObject bullet_3;
    public GameObject bullet_8;
    public GameObject bullet_target_9;

    void Start()
    {
        transform = GetComponent<Transform>();
        quaternion = transform.rotation;
        StartCoroutine(pattern());
    }

    void Update()
    {
        Timer();
        Shoot();
        if (shoot == 9)
            return;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 30));
    }

    void Timer()
    {
        t_pattern -= Time.deltaTime;
        if (t_pattern <= 0)
        {
            random = Random.Range(1, 4);
            StartCoroutine(pattern());
        }
    }

    void Shoot()
    {
        t_shoot += Time.deltaTime;
        if (t_shoot < fireRate) return;

        if (shoot == 1)
        {
            Instantiate(bullet, transform);
            t_shoot = 0;
        }
        else if (shoot == 3)
        {
            Instantiate(bullet_3, transform);
            t_shoot = 0;
        }
        else if (shoot == 8)
        {
            Instantiate(bullet_8, transform);
            t_shoot = 0;
        }
        else if (shoot == 9)
        {
            Instantiate(bullet_target_9, transform.position, Quaternion.Euler(0, 0, 0));
            t_shoot = 0;
        }
    }

    IEnumerator pattern()
    {
        if (random == 1)
        {
            t_pattern = 1.1f;
            shoot = 1;
            t_corutine = 0;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            while (t_corutine <= 1)
            {
                t_corutine += Time.deltaTime;
                fireRate = 0.01f;
                transform.Rotate(new Vector3(0, 0, 1000) * Time.deltaTime);
                yield return null;
            }
        }
        else if (random == 2)
        {
            t_pattern = 5.1f;
            t_corutine = 0;
            shoot = 8;
            while (t_corutine <= 5)
            {
                t_corutine += Time.deltaTime;
                fireRate = 0.06f;
                transform.Rotate(new Vector3(0, 0, 500) * Time.deltaTime);
                yield return null;
            }
        }
        else if (random == 3)
        {
            t_pattern = 5f;
            fireRate = 0.01f;

            t_corutine = 0;
            while (t_corutine <= 0.5)
            {
                shoot = 9;
                t_shoot = -1;
                t_corutine += Time.deltaTime;
                yield return null;
            }
            for (int i = 0; i < 10; i++)
            {
                shoot = 9;
                t_corutine = 0;
                while (t_corutine <= 0.2)
                {
                    t_corutine += Time.deltaTime;
                    yield return null;
                }
                shoot = 0;
                t_corutine = 0;
                while (t_corutine <= 0.2)
                {
                    t_corutine += Time.deltaTime;
                    yield return null;
                }
            }
        }
        shoot = 0;
        t_corutine = 0;
        yield return null;
    }
}
