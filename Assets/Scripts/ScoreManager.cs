using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highestScore;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI totalScoreUI;
    [SerializeField] private TextMeshProUGUI highestScoreUI;

    private void Awake()
    {
        score = 0;
        highestScore = PlayerPrefs.GetInt("highestScore", 0);
    }
    private void Start()
    {
        Meteor.meteorDied += ScoreManager_meteorDied;
        Player.OnPlayerDeath += ScoreManager_OnPlayerDeath;
    }

    private void Update()
    {
    }
    private void ScoreManager_OnPlayerDeath()
    {
        if(highestScore < score)
        {
            highestScore = score;
            highestScoreUI.text = "Highest Score: " + highestScore.ToString();
            PlayerPrefs.SetInt("highestScore",highestScore);
            PlayerPrefs.Save();
        }
        else
        {
            highestScoreUI.text = "Highest Score: " + highestScore.ToString();
        }
        totalScoreUI.text ="Score: " + score.ToString();
    }

    private void ScoreManager_meteorDied(Meteor obj)
    {
        switch (obj.meteorType)
        {
            case Meteor.MeteorType.small:
                score += 100;
                break;
            case Meteor.MeteorType.medium:
                score += 70;
                break;
            case Meteor.MeteorType.large:
                score += 50;
                break;
        }
        scoreUI.text = score.ToString();
    }

    private void OnDestroy()
    {
        Meteor.meteorDied -= ScoreManager_meteorDied;
        Player.OnPlayerDeath -= ScoreManager_OnPlayerDeath;
    }
}
