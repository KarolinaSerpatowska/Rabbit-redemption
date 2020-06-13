using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private int scoreleft = 0;
    private int scoreright = 0;
    public Text textScoreLeft;
    public Text textScoreRight;

    public Player player1;
    public Player player2;

    void Start()
    {
        scoreleft = 0;
        scoreright = 0;
        SetCountText();
    }

    void Update()
    {
        count();
        SetCountText();
    }


    void count()
    {
        scoreleft = player1.pkt;
        scoreright = player2.pkt;
    }

    public void SetCountText()
    {
        textScoreLeft.text = "Points: " + scoreleft.ToString();
        textScoreRight.text = "Points: " + scoreright.ToString();
    }
}
