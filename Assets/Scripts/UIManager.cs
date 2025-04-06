using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIManager : MonoBehaviour
{
    //Variable List
    public GameObject gameOverPanel;
    public GameObject GameUIPanel;
    public TMP_Text Scoretext;
    public TMP_Text GameUI_Scoretext;
    //public TMP_Text HighScoretext;



    //Singleton Pattern Definition
    private static UIManager instance;


    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindFirstObjectByType<UIManager>();
            }

            return instance;
        }
    }

    public void UpdateUserScore(int score)
    {
        GameUI_Scoretext.text = "Score:"+score;
    }

    public void HandleGameOverUI()
    {

        gameOverPanel.SetActive(true);
        GameUIPanel.SetActive(false);
        Scoretext.text = "Your Score :" + GameManager.Instance.score;
        //HighScoretext.text = "High Score :" + GameManager.Instance.score;
    }

    public void ReloadGame()
    {

        SceneManager.LoadScene("SampleScene");

    }

}
