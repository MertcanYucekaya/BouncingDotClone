using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBall : MonoBehaviour
{
    public float jumpAmount;
    public Sprite[] sprites;
    Rigidbody2D rigi;
    int random;
    public float waitForSecond;
    public Text scoreText;
    int score = 0;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        random = 2;
        transform.tag = random.ToString();
        scoreText.text = "Score: " + score;
        if (!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", 0);
        }
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name.Equals(random.ToString()))
        {
            random =Random.Range(0, sprites.Length);
            GetComponent<SpriteRenderer>().sprite = sprites[random];
            transform.tag = random.ToString();
            rigi.velocity = new Vector2(0, jumpAmount);
            score++;
            if (score > PlayerPrefs.GetInt("bestScore"))
            {
                PlayerPrefs.SetInt("bestScore", score);
            }
            scoreText.text = "Score: " + score;
        }
        else
        {
            PlayerPrefs.SetInt("currentScore",score);
            collision.transform.GetComponent<PolygonCollider2D>().enabled = false;
            Invoke("gameOver", waitForSecond);
        }
    }
    void gameOver()
    {
        SceneManager.LoadScene(0);
    }

}
