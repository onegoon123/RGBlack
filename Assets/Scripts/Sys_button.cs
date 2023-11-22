using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sys_button : MonoBehaviour {

    public void button_Ready() {
        SceneManager.LoadSceneAsync(1);
    }

    public void button_Start() {
        GameObject.Find("Up").GetComponent<Sys_UP>().Set();
        SceneManager.LoadScene(2);
    }

    public void button_UP_Attack() {
        if(GameManager.instance.UP_point >= GameManager.instance.UP_use && GameManager.instance.LV_attack < 10) {
            GameManager.instance.UP_point -= GameManager.instance.UP_use;
            GameManager.instance.LV_attack++;
        }
        GameObject.Find("Up").GetComponent<Sys_UP>().Set();
    }

    public void button_UP_HP()
    {
        if (GameManager.instance.UP_point >= GameManager.instance.UP_use && GameManager.instance.LV_HP < 3)
        {
            GameManager.instance.UP_point -= GameManager.instance.UP_use;
            GameManager.instance.LV_HP++;
        }
        GameObject.Find("Up").GetComponent<Sys_UP>().Set();
    }

    public void button_UP_Skill()
    {
        if (GameManager.instance.UP_point >= GameManager.instance.UP_use && GameManager.instance.LV_skill < 10)
        {
            GameManager.instance.UP_point -= GameManager.instance.UP_use;
            GameManager.instance.LV_skill++;
        }
        GameObject.Find("Up").GetComponent<Sys_UP>().Set();
    }

    public void button_difficulty() {
        if (GameManager.instance.difficulty == 0) {
            GameManager.instance.difficulty = 1;
            GameObject.Find("difficulty").GetComponent<Text>().text = "보통";
        }
        else if (GameManager.instance.difficulty == 1) {
            GameManager.instance.difficulty = 2;
            GameObject.Find("difficulty").GetComponent<Text>().text = "어려움";
        }
        else if (GameManager.instance.difficulty == 2) {
            GameManager.instance.difficulty = 3;
            GameObject.Find("difficulty").GetComponent<Text>().text = "지옥";
        }
        else if (GameManager.instance.difficulty == 3)
        {
            GameManager.instance.difficulty = 0;
            GameObject.Find("difficulty").GetComponent<Text>().text = "쉬움";
        }
    }
}
