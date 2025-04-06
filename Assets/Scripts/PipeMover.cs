using Unity.VisualScripting;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    //Variable list
    public int movespeed = 5;

    //Function
    void Update()
    {
        if(!GameManager.Instance.gameOver)
            transform.position -= new Vector3(movespeed * Time.deltaTime, 0, 0);

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }

    
}
