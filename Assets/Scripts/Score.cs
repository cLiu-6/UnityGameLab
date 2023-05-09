using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] public static int score = 0;
    [SerializeField] public TextMeshProUGUI scoreTxt;
    [SerializeField] public TextMeshProUGUI sceneTxt;
    [SerializeField] int level;

    const int DEFAULT_POINTS = 4;
    const int REDUCED_POINTS = 3;
    private static float scoreThreshold = 6;
    static int tempScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        sceneTxt.text = "Level: " + (level);
        scoreTxt.text = "Score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score;

    }

    public static void AddPoints(int points)
    {
        score += points;
        tempScore += points;
        PersistentData.Instance.SetScore(score);
        //Scene currentScene = SceneManager.GetActiveScene ();
        //string sceneName = currentScene.name;
    
        if (score >= scoreThreshold)
        {
            AdvanceLevel();
            if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Level 2"))
            {
                scoreThreshold = score + 9;

            } 
            else
            {
                scoreThreshold = score + 6;
            }
            tempScore = 0;
        }

    }

    public static void AddPoints()
    {
            
        if (TargetMovement.xy.x <= 8f)
        {
            AddPoints(DEFAULT_POINTS);  
        }
        else
        {
            AddPoints(REDUCED_POINTS);
        }
       
    } 

    public static void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void Reset()
    {
        score = 0;
        scoreThreshold = 6;
    }

    public static void ResetScore()
    {
        score -= tempScore;
        tempScore = 0;
    }
}
