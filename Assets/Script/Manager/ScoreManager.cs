using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text myScoreText;
    private int score;

    void Start()
    {
       score = 0;
    }
    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.tag == "Coins")
        {
            score += 1;
            Destroy(coin.gameObject);
            myScoreText.text = "X" + score;
        }
    }
}
