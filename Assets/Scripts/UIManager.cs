using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Variable List
    public GameObject gameOverPanel;
    public GameObject GameUIPanel;
    public TMP_Text Scoretext;
    public TMP_Text GameUI_Scoretext;
    public TMP_Text HighScoretext; // Optional, for high score display

    // Singleton Pattern Definition
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindFirstObjectByType<UIManager>();
            return instance;
        }
    }

    void Awake()
    {
        // Disable all game-related UI at game start (menu)
        gameOverPanel.SetActive(false);
        GameUIPanel.SetActive(false);
        Scoretext.gameObject.SetActive(false);
        if (HighScoretext != null)
            HighScoretext.gameObject.SetActive(false);
    }

    // Call this when the game actually starts
    public void StartGameUI()
    {
        GameUIPanel.SetActive(true);
        Scoretext.gameObject.SetActive(true);
        if (HighScoretext != null)
            HighScoretext.gameObject.SetActive(true);
    }


    public void UpdateUserScore(int score)
    {
        GameUI_Scoretext.text = "SCORE: " + score;
        if (Scoretext != null)
            Scoretext.text = "YOUR SCORE: " + score;
    }

    public void UpdateHighScore(int highscore)
    {
        if (HighScoretext != null)
            HighScoretext.text = "HIGH SCORE: " + highscore;
    }

    public void HandleGameOverUI()
    {
        gameOverPanel.SetActive(true);
        GameUIPanel.SetActive(false);
        Time.timeScale = 0;
        Scoretext.gameObject.SetActive(true);
        if (HighScoretext != null)
            HighScoretext.gameObject.SetActive(true);
        // Assuming GameManager.Instance.score and .highscore are available
        Scoretext.text = "YOUR SCORE: " + GameManager.Instance.score;
        if (HighScoretext != null)
            HighScoretext.text = "HIGH SCORE: " + GameManager.Instance.highscore;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1; // In case it was paused
        SceneManager.LoadScene("SampleScene"); // Ensure your game scene matches this name
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene"); // Change to your menu scene name
    }

    // For hiding score text as needed (e.g. menu)
    public void HideScoreText()
    {
        Scoretext.gameObject.SetActive(false);
        if (HighScoretext != null)
            HighScoretext.gameObject.SetActive(false);
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }



    public void HideGameUI()
    {
        GameUIPanel.SetActive(false);
        Scoretext.gameObject.SetActive(false);
        if (HighScoretext != null)
            HighScoretext.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        //GameManager.Instance.UIManager();
        Application.Quit();
    }
}
