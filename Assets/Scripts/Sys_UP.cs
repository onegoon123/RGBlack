using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sys_UP : MonoBehaviour {

    void Start () {
        Set();
    }

    public void Set() {
        PlayerPrefs.SetInt("Attack LV", GameManager.instance.LV_attack);
        PlayerPrefs.SetInt("HP LV", GameManager.instance.LV_HP);
        PlayerPrefs.SetInt("Skill LV", GameManager.instance.LV_skill);
        PlayerPrefs.SetInt("point", GameManager.instance.UP_point);
        PlayerPrefs.SetInt("usepoint", GameManager.instance.UP_use);

        if (GameManager.instance.difficulty == 1)
        {
            GameObject.Find("difficulty").GetComponent<Text>().text = "보통";
        }
        else if (GameManager.instance.difficulty == 2)
        {
            GameObject.Find("difficulty").GetComponent<Text>().text = "어려움";
        }
        else if (GameManager.instance.difficulty == 0)
        {
            GameObject.Find("difficulty").GetComponent<Text>().text = "쉬움";
        }
        else if (GameManager.instance.difficulty == 3)
        {
            GameObject.Find("difficulty").GetComponent<Text>().text = "지옥";
        }

        


        if (GameManager.instance.LV_attack < 10)
            GameObject.Find("AttackLV").GetComponent<Text>().text = GameManager.instance.LV_attack.ToString();
        else {
            GameObject.Find("AttackLV").GetComponent<Text>().text = "Max";
            GameObject.Find("AU").GetComponent<Text>().text = " ";
        }

        if (GameManager.instance.LV_HP < 3)
            GameObject.Find("HPLV").GetComponent<Text>().text = GameManager.instance.LV_HP.ToString();
        else {
            GameObject.Find("HPLV").GetComponent<Text>().text = "Max";
            GameObject.Find("HU").GetComponent<Text>().text = " ";
        }

        if (GameManager.instance.LV_skill < 10)
            GameObject.Find("SkillLV").GetComponent<Text>().text = GameManager.instance.LV_skill.ToString();
        else {
            GameObject.Find("SkillLV").GetComponent<Text>().text = "Max";
            GameObject.Find("SU").GetComponent<Text>().text = " ";
        }

        GameObject.Find("point").GetComponent<Text>().text = GameManager.instance.UP_point.ToString();

        GameManager.instance.UP_use = (GameManager.instance.LV_attack + GameManager.instance.LV_HP + GameManager.instance.LV_skill) / 3;
        GameObject.Find("usepoint").GetComponent<Text>().text = GameManager.instance.UP_use.ToString();



        GameManager.instance.damage = 1 + (GameManager.instance.LV_attack * 0.2f);
        GameManager.instance.fireRate = 0.4f - (0.03f * GameManager.instance.LV_attack);

        GameManager.instance.MaxHP = 3 + GameManager.instance.LV_HP;

        GameManager.instance.UseSP = 25f - GameManager.instance.LV_skill;
        GameManager.instance.skill_size = 2 + GameManager.instance.LV_skill * 0.25f;
        GameManager.instance.skill_time = 2 + (GameManager.instance.LV_skill * 0.3f);
        if (GameManager.instance.LV_skill == 10)
            GameManager.instance.skill_shoot = true;

        
    }

	void Update () {
		
	}
}
