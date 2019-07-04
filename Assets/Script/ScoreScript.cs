using System.Collections;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMesh Score;
    public TextMesh Best;

    public static int score = 0;
    private int best = 0;

    void Start()
    {
        best = PlayerPrefs.GetInt("score", score);
        Score.text = "Score " + score.ToString();
        Best.text = best.ToString();
    }


    IEnumerator ScorePlus() 
    {
        yield return new WaitForSeconds(1f);
        score++;
    }


    void Update()
    {
        ScorePlus();
        if (score > best) 
        {
            PlayerPrefs.SetInt("savescore", score);
            PlayerPrefs.Save();
            best = score;
        }
        best = PlayerPrefs.GetInt("savescore");
        Best.text = best.ToString();
        Score.text = "Score " + score.ToString();

    }
}
