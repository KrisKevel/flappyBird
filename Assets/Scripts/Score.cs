using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public static int ScoreCounter = 0;


    void Start()
    {

        ScoreText.text = "Score: " + ScoreCounter;

    }


    void Update()
    {
        ScoreText.text = "Score: " + ScoreCounter;
    }
}
