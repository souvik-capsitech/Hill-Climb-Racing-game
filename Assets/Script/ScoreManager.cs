using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ScoreManager instance;

    private int score;

    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateScore();   
    }

    // Update is called once per frame
    private void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "" + score;
        }
    }


    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    public int GetScore()
    {
        return score;
    }
}
