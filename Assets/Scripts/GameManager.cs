using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        GameManager.instance.LV_attack = PlayerPrefs.GetInt("Attack LV");
        GameManager.instance.LV_HP = PlayerPrefs.GetInt("HP LV");
        GameManager.instance.LV_skill = PlayerPrefs.GetInt("Skill LV");
        GameManager.instance.UP_point = PlayerPrefs.GetInt("point");
        GameManager.instance.UP_use = PlayerPrefs.GetInt("usepoint");

        if (LV_attack <= 0) LV_attack = 1;
        if (LV_HP <= 0) LV_HP = 1;
        if (LV_skill <= 0) LV_skill = 1;
        if (UP_point <= 0) UP_point = 1;
        if (UP_use <= 0) UP_use = 1;
    }

    public int LV_attack = 1;
    public int LV_HP = 1;
    public int LV_skill = 1;
    public int UP_point = 1;
    public int UP_use = 1;
    public int difficulty = 0;

    public float damage;          // 공격력
    public float fireRate;      // 연사 속도
    public int MaxHP;           // 최대 체력
    public float UseSP;         // 스킬 쿨타임
    public float skill_size;    // 스킬 크기
    public float skill_time;    // 스킬 지속시간
    public bool skill_shoot;    // 스킬 발사(적에게 날라가기) 여부
}
