using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDispley;

    void Update()
    {
        scoreDispley.text = "�ר�: " + score.ToString();
    }

    public void Kill()
    {
        score++;
    }
}
