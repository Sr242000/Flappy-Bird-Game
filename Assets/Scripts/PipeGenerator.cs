using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    //Variable list
    public GameObject pipes;
    public float LowerUpperrange = 2f;

    public PlayerController player;


    //Function
    void Start()
    {
        if (pipes == null)
        {
            Debug.LogError("Pipes prefab is not assigned!");
            return;
        }

        InvokeRepeating(nameof(SpawnPipes), 1f, 1f);
    }

    void SpawnPipes()
    {
        if (!GameManager.Instance.gameOver && GameManager.Instance.hasgamestarted)
        {
            Instantiate(pipes, new Vector3(transform.position.x, Random.Range(-LowerUpperrange, LowerUpperrange), 0), Quaternion.identity);
        }
    }
}
