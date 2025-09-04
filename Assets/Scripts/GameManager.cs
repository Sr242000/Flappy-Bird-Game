using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable list
    public int score = 0;
    public int highscore = 0;
    public bool gameOver = false;
    public bool hasgamestarted = false;
    public Rigidbody2D PlayerControllerRigidBody;

    // Singleton Pattern Definition
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindFirstObjectByType<GameManager>();
            return instance;
        }
    }

    void Awake()
    {
        // Load high score at startup
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    void Start()
    {
        score = 0;
        gameOver = false;
        hasgamestarted = false;
        PlayerControllerRigidBody.gravityScale = 0;
        UIManager.Instance.UpdateUserScore(score);
        UIManager.Instance.UpdateHighScore(highscore);
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
        UIManager.Instance.GameUIPanel.SetActive(true);
        UIManager.Instance.gameOverPanel.SetActive(false);
    }

    public bool Score()
    {
        score++;
        UIManager.Instance.UpdateUserScore(score);
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            UIManager.Instance.UpdateHighScore(highscore);
        }
        AudioManager.Instance.PlayScoreSound();
        return true;
    }

    public void ResetGame()
    {
        score = 0;
        gameOver = false;
        hasgamestarted = false;
        PlayerControllerRigidBody.gravityScale = 0;
        UIManager.Instance.UpdateUserScore(score);
        UIManager.Instance.UpdateHighScore(highscore);
        UIManager.Instance.gameOverPanel.SetActive(false);
        UIManager.Instance.GameUIPanel.SetActive(true);
    }
}
