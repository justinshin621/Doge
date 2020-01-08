using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //Must use this in order to access Text component
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        score = 0;
    }

    private void Update()
    {
        if (score < 0)
            score = 0;

        text.text = "" + score;

    }

    // adds points to the score
    public static void AddPoints(int pointToAdd)
    {
        score += pointToAdd;
    }

    // if you want player to lose all points
    public static void Reset()
    {
        score = 0;
    }
}
