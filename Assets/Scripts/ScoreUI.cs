using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;

    public Text scoreText;
    public Text Highscore;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public bool scoreGoing = true;

    void Awake()
    {
        Instance = this;

        //This displays the Highscore of the player.It won't convert to the old score.
        Highscore.text = "" + (int)PlayerPrefs.GetFloat("");
    }

    void Update()
    {
        Highscore.text = "" + (int)PlayerPrefs.GetFloat("");

        //This will replace the score of the Highscore if the score if more than the Highscore.
        if (PlayerPrefs.GetFloat("") < scoreAmount)
            PlayerPrefs.SetFloat("", scoreAmount);

        //SCORE
        if (scoreGoing == true)
        {
            //Increases the speed of the score.
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
            scoreText.text = "" + (int)scoreAmount;
        }
        else if (scoreGoing == false)
        {
            scoreText.text = "" + (int)scoreAmount;
        }
    }
}
