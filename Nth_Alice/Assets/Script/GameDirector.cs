using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject hpGauge;
    public GameObject image;
    public GameObject text1;
    public GameObject text2;
    public GameObject alice;
    public GameObject score;

    private float hp;
    private float hp_max = 100;
    private float hp_delta = 20;
    private float fadeCount;
    private float scorePoint;
    private bool gameOver = false;
    private bool sceneMove = false;

    private Color color;
    private Color color1;
    private Color color2;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        this.image = GameObject.Find("Image");
        this.text1 = GameObject.Find("GameOverText1");
        this.text2 = GameObject.Find("GameOverText2");
        this.alice = GameObject.Find("alice");
        this.score = GameObject.Find("score");

        this.color = image.GetComponent<Image>().color;
        this.color1 = text1.GetComponent<Text>().color;
        this.color2 = text2.GetComponent<Text>().color;

        this.hp = this.hp_max;
    }

    void Update()
    {
        if (gameOver == false)
        {
            scorePoint += Time.deltaTime;
            score.GetComponent<Text>().text = "SCORE: " + Mathf.Round(scorePoint)*10;
        }

        if (this.hp == 0) {
            gameOver = true;

            this.fadeCount += Time.deltaTime;
            
            color.a = fadeCount;
            color1.a = fadeCount;
            color2.a = fadeCount;
            image.GetComponent<Image>().color = color;
            text1.GetComponent<Text>().color = color1;
            text2.GetComponent<Text>().color = color2;
            
            if ((color.a > 1.0f) & (sceneMove == false)) {
                this.fadeCount = 0;
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                sceneMove = true;
            }
        }
    }

    public void DecreaseHp()
    {
        this.hp -= this.hp_delta;
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.2f;
    }
}
