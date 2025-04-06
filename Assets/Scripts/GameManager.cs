using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    //Variable list
    public int score = 0;
    public int highscore = 0;
    public bool gameOver = false;
    public bool hasgamestarted = false;
    public Rigidbody2D PlayerControllerRigidBody;


    //Singleton Pattern Definition
    private static GameManager instance;

    public static GameManager Instance
    {
        get {
            if (instance == null)
            {
                instance = GameObject.FindFirstObjectByType<GameManager>();
            }

            return instance;
        }
    }

    //Function List

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore:",0);
        PlayerControllerRigidBody.gravityScale = 0;
    }
    public void GameOver()
    {
        gameOver = true;
        AudioManager.Instance.PlayGameOverSound();
        UIManager.Instance.HandleGameOverUI();

    }

    public void GameStart()
    {
        hasgamestarted = true;
        PlayerControllerRigidBody.gravityScale = 1;
    }

    public bool Score()
    {
        score++;
        UIManager.Instance.UpdateUserScore(score);
        if (score < highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore:", highscore);
        }
        AudioManager.Instance.PlayScoreSound();
        return true;
    }

}
