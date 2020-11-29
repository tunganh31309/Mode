using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    private int score;

    [SerializeField]
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
