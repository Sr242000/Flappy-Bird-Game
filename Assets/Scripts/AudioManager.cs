using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Variable list
    public AudioClip ScoreSound;
    public AudioClip GameOverSound;

    //Singleton Pattern Definition
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindFirstObjectByType<AudioManager>();
            }

            return instance;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Function
    public void PlayScoreSound()
    {
        AudioSource.PlayClipAtPoint(ScoreSound, Camera.main.transform.position);
    }

    // Update is called once per frame
    public void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(GameOverSound, Camera.main.transform.position);
    }
}
