using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBall : MonoBehaviour
{
    Rigidbody2D rigi;
    public float jumpAmount;
    public Sprite[] sprites;
    public Text bestScore;
    public Text currentScore;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        bestScore.text = "Best: " + PlayerPrefs.GetInt("bestScore");
        currentScore.text = "Score: " + PlayerPrefs.GetInt("currentScore");
    }

   
    void Update()
    {
        if(rigi.velocity==new Vector2(0, 0))
        {
            int random = Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[random];
            rigi.velocity = new Vector2(0, jumpAmount);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
